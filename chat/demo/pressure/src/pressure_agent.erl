%%%===================================================================
%%% @author z.hua
%%% @doc
%%%
%%% @end
%%%===================================================================

-module(pressure_agent).

-behaviour(gen_server).

%% gen_server callbacks
-export([init/1, handle_call/3, handle_cast/2, handle_info/2, terminate/2, code_change/3]).
%% API
-export([start_link/4, new_table/0]).
-export([encode/2, decode/1]).

-record(state, {id, sock, role_id, scene_id, x, y, ard_roles = [], ard_mons = [], skills = []}).


%%%-------------------------------------------------------------------
%%% API Functions
%%%-------------------------------------------------------------------
start_link(ID, SceneID, X, Y) ->
	gen_server:start_link(?MODULE, {ID, SceneID, X, Y}, []).

new_table() ->
    ets:new(role_state, [set, named_table, public, {keypos, #state.id}]).

%%%-------------------------------------------------------------------
%%% Callback Functions
%%%-------------------------------------------------------------------
init({ID, SceneID, X, Y}) ->
    process_flag(trap_exit, true),
	{ok, Host} = application:get_env(host),
	{ok, Port} = application:get_env(port),
	case gen_tcp:connect(Host, Port, [binary, {packet,0}, {active,false}], 5000) of
		{ok, Sock} ->
			State = #state{id = ID, sock = Sock, scene_id = SceneID, x = X, y = Y},
			do_auth(State),
            ets:insert(role_state, State),
            Pid = spawn_link(fun() -> timer_do(ID, Sock, self()) end),
			erlang:send_after(5000, Pid, heartbeat),
			erlang:send_after(10000, Pid, random_act),
			{ok, State, 0};
		{error, Err} ->
			{stop, Err}
	end.

handle_call(_Request, _From, State) ->
	{reply, {error, unknown_call}, State}.

handle_cast(_Msg, State) ->
	{noreply, State}.

handle_info(timeout, State = #state{sock = Sock}) ->
	{ok, <<Len:32>>} = gen_tcp:recv(Sock, 4),
	{ok, Bin} = gen_tcp:recv(Sock, Len - 4),
	case catch decode(Bin) of
		{ok, Cmd, Data} ->
			case do_handle_info(Cmd, Data, State) of
				{ok, NewSt} ->
                    ets:insert(role_state, NewSt),
					{noreply, NewSt, 0};
				{stop, Reason} ->
					error_logger:error_msg("stop, reason:~p~n", [Reason]),
					{stop, Reason, State};
				_ ->
					{noreply, State, 0}
			end;
		Error ->
			error_logger:error_msg("decode_error:~p~n", [Error]),
			{stop, normal, State}
	end;
handle_info(exit, State) ->
    error_logger:error_msg("timer do exit"),
    {stop, exit, State};
handle_info(Info, State) ->
	error_logger:error_msg("unhandle info:~p~n", [Info]),
	{noreply, State, 0}.

terminate(_Reason, _State) ->
	ok.

code_change(_OldVsn, State, _Extra) ->
	{ok, State}.

%%%-------------------------------------------------------------------
%%% Internal Functions
%%%-------------------------------------------------------------------

timer_do(Id, Socket, Pid) ->
    receive
        heartbeat ->
            gen_tcp:send(Socket, encode(10006, <<>>)),
            erlang:send_after(6000, self(), heartbeat);
        random_act ->
            case ets:lookup(role_state, Id) of
                [State] ->
                    case random(1, 2) of
                        1 ->
                            do_walk(State);
                        2 ->
                            do_attack(State)
                    end,
                    erlang:send_after(500, self(), random_act);
                _ ->
                    erlang:send(Pid, exit)
            end;
        _ -> ignore
    end,
    timer_do(Id, Socket, Pid).

%% 验证
do_handle_info(10000, <<_:8, _:64, Len:16, Bin/binary>>, State) ->
	case Len of
		0 ->
			do_create(State);
		1 ->
			<<RoleID:32, _/binary>> = Bin,
			State2 = State#state{role_id = RoleID},
			do_login(State2),
			{ok, State2}
	end;
%% 创角
do_handle_info(10003, <<Err:8, RoleID:32>>, State) ->
	case Err of
		1 ->
			State2 = State#state{role_id = RoleID},
			do_login(State2),
			{ok, State2};
		_ ->
			{stop, {create_error, Err}}
	end;
%% 登录
do_handle_info(10004, <<Err:8>>, State) ->
	case Err of
		1 ->
			do_get_info(State),
			do_get_skills(State),
			do_switch(State);
		_ ->
			{stop, {login_error, Err}}
	end;
%% 角色信息
do_handle_info(13001, _, State) ->
	do_enter_scene(State);
%% 切换到新场景
do_handle_info(12005, _, #state{sock = Sock}) ->
	gen_tcp:send(Sock, encode(12002, <<>>));
%% 加载场景信息
do_handle_info(12002, Bin, State) ->
	<<Len1:16, Rem1/binary>> = Bin,
	{Rem2, Roles} = decode_roles(Rem1, Len1, []),
	<<Len2:16, Rem3/binary>> = Rem2,
	{_, Mons} = decode_mons(Rem3, Len2, []),

	{ok, State#state{ard_roles = Roles, ard_mons = Mons}};
%% 获取技能列表
do_handle_info(21002, <<_:8, _:16, Bin/binary>>, State) ->
	Skills = decode_skills(Bin, []),
	{ok, State#state{skills = Skills}};
do_handle_info(_Cmd, _Bin, _) ->
	ignore.

decode_skills(<<SkillID:32, _:8, _:32, Rem/binary>>, Acc) ->
	decode_skills(Rem, [SkillID | Acc]);
decode_skills(<<>>, Acc) ->
	Acc.

decode_roles(Bin, 0, Acc) ->
	{Bin, Acc};
decode_roles(Bin, Len, Acc) ->
	<<RoleID:32, L0:16, Pf:L0/binary-unit:8, SrvID:16, L1:16, _:L1/binary-unit:8, _:8, _:16,
	X:16, Y:16, _:32, _:32, _:32, _:32, _:8, _:32, _:32, _:8, _:32, L7:16, Rem1/binary>> = Bin,
	Rem2 = decode_role_designs(Rem1, L7),
	<<_:16, _:8, _:32, L2:16, _:L2/binary-unit:8, _:8, _:32, L3:16, _:L3/binary-unit:8, _:8, _:8,
	_:32, _:8, _:32, _:32, _:8, L4:16, _:L4/binary-unit:8, _:32, _:16, _:32, _:32, _:32, _:8, _:8,
	_:32, _:32, L5:16, _:L5/binary-unit:8, _:32, _:8, _:16, _:16, _:8, _:8, _:32, _:16, _:32, _:32,
	_:8, _:32, _:32, _:8, L6:16, _:L6/binary-unit:32, _:8, _:32, _:8, _:8, _:8, _Zazen:8, Rem3/binary>> = Rem2,
	decode_roles(Rem3, Len - 1, [{RoleID, Pf, SrvID, X, Y} | Acc]).


decode_role_designs(Bin, 0) ->
	Bin;
decode_role_designs(Bin, Len) ->
	<<_:32, L:16, _:L/binary-unit:8, Rem/binary>> = Bin,
	decode_role_designs(Rem, Len-1).

decode_mons(Bin, 0, Acc) ->
	{Bin, Acc};
decode_mons(Bin, Len, Acc) ->
	<<X:16, Y:16, MonID:32, _:32, _:64, _:64, _:16, L0:16, _:L0/binary-unit:8, _:16, _:32, _:8, _:8,
	_:8, _:8, _:8, _:32, _:32, _:8, _:8, _:32, _:8, _:8, _:8, _:32, L1:16, _:L1/binary-unit:8, _:32,
	L2:16, _GuildName:L2/binary-unit:8, Rem/binary>> = Bin,
	decode_mons(Rem, Len-1, [{MonID, X, Y} | Acc]).



do_auth(#state{id = AccID, sock = Sock}) ->
	AccName = lists:concat(["zxy_", AccID]),
	TStamp  = seconds(),
	Ticket  = my_md5( lists:concat([AccID, AccName, TStamp, "SDFSDESF123DFSDF"]) ),
	Data = <<AccID:32, TStamp:32, (write_string(AccName))/binary, (write_string(Ticket))/binary>>,
	gen_tcp:send(Sock, encode(10000, Data)).

do_create(#state{id = ID, sock = Sock}) ->
	Name = lists:concat(["rb", ID]),
	Src  = "zxy",
	Data = <<0:8, 1:8, 1:8, (write_string(Name))/binary, (write_string(Src))/binary>>,
	gen_tcp:send(Sock, encode(10003, Data)).

do_login(State = #state{sock = Sock, role_id = RoleID}) ->
	TStamp = seconds(),
	Ticket = my_md5( lists:concat([TStamp, RoleID, "7YnELt8MmA4jVED7"]) ),
	Data = <<RoleID:32, TStamp:32, (write_string(Ticket))/binary>>,
	gen_tcp:send(Sock, encode(10004, Data)),
	do_gm(State).

do_gm(#state{sock = Sock, role_id = RoleID}) ->
	TStamp = seconds(),
	Ticket = my_md5( lists:concat([RoleID, TStamp, "7YnELt8MmA4jVED7"]) ),
	Data = <<(write_string("robot"))/binary, TStamp:32, (write_string(Ticket))/binary>>,
	gen_tcp:send(Sock, encode(11101, Data)).


do_get_info(#state{sock = Sock}) ->
	gen_tcp:send(Sock, encode(13001, <<>>)).

do_get_skills(#state{sock = Sock}) ->
	gen_tcp:send(Sock, encode(21002, <<>>)).

do_switch(#state{sock = Sock}) ->
	gen_tcp:send(Sock, encode(13012, <<2:8>>)).

do_enter_scene(State = #state{sock = Sock, scene_id = SceneID, x = X0, y = Y0}) ->
	Data = <<0:32, SceneID:32, 0:8>>,
	gen_tcp:send(Sock, encode(12005, Data)),
	gen_tcp:send(Sock, encode(12027, <<>>)),
	{A1,A2,A3} = erlang:timestamp(),
	random:seed(A1, A2, A3),
	X = X0 + random(-500, 500),
	Y = Y0 + random(-500, 500),
	Data2 = <<SceneID:32, X:16, Y:16, 2:8, X:16, Y:16>>,
	gen_tcp:send(Sock, encode(12001, Data2)),
	{ok, State#state{scene_id = SceneID, x = X, y = Y}}.

do_walk(State = #state{sock = Sock, scene_id = SceneID, x = X0, y = Y0}) ->
	{A1,A2,A3} = erlang:timestamp(),
	random:seed(A1, A2, A3),
	X = X0 + random(-200, 200),
	Y = Y0 + random(-200, 200),
	Data = <<SceneID:32, X:16, Y:16, 0:8, X:16, Y:16>>,
	gen_tcp:send(Sock, encode(12001, Data)),
	{ok, State#state{x = X, y = Y}}.

do_attack(#state{sock = Sock, ard_roles = ArdRoles, ard_mons = ArdMons, skills = Skills, x = X1, y = Y1}) ->
	case Skills == [] of
		true  ->
			ignore;
		false ->
			case ArdRoles == [] andalso ArdMons == [] of
				true  ->
					ignore;
				false ->
					TStamp  = seconds(),
					SkillID = lists:nth(random(1, length(Skills)), Skills),
					Mons  = <<(length(ArdMons)):16, (encode_mons(ArdMons, <<>>))/binary>>,
					Roles = <<(length(ArdRoles)):16, (encode_roles(ArdRoles, <<>>))/binary>>,
					{Dir, _SX, _SY} = case ArdRoles of
						[{_, _, _, X2, Y2} | _] ->
							get_direction(X1, Y1, X2, Y2);
						_ ->
							case ArdMons of
								[{_, X2, Y2} | _] ->
									get_direction(X1, Y1, X2, Y2);
								_ ->
									1
							end
					end,
					Data  = <<1:8, Mons/binary, Roles/binary, SkillID:32, Dir:8, (X1):16, (Y1):16,
						X1:16, Y1:16, TStamp:32, (write_string("ticket"))/binary>>,
					gen_tcp:send(Sock, encode(20001, Data))
			end
	end.

get_direction(X1, Y1, X2, Y2) when X2 =< X1 andalso Y2 =< Y1 ->
	{1, X1-100, Y1-100};
get_direction(X1, Y1, X2, Y2) when X2 =< X1 andalso Y2 > Y1 ->
	{7, X1-100, Y1+100};
get_direction(X1, Y1, X2, Y2) when X2 >= X1 andalso Y2 >= Y1 ->
	{9, X1+100, Y1+100};
get_direction(X1, Y1, X2, Y2) when X2 >= X1 andalso Y2 < Y1 ->
	{3, X1+100, Y1-100}.


encode_mons([{MonID, _, _} | T], Acc) ->
	encode_mons(T, <<MonID:32, Acc/binary>>);
encode_mons([], Acc) ->
	Acc.

encode_roles([{RoleID, Pf, SrvID, _, _} | T], Acc) ->
	Bin = <<RoleID:32, (write_string(Pf))/binary, SrvID:16>>,
	encode_roles(T, <<Bin/binary, Acc/binary>>);
encode_roles([], Acc) ->
	Acc.

seconds() ->
    {A, B, _} = os:timestamp(),
    A * 1000000 + B.

my_md5(S) ->
    lists:flatten([io_lib:format("~2.16.0b",[N]) || N <- binary_to_list(erlang:md5(S))]).

random(Min, Max)->
    Min2 = Min - 1,
    random:uniform(Max-Min2) + Min2.

write_string(Str) ->
    Bin = iolist_to_binary(Str),
    Len = byte_size(Bin),
    <<Len:16, Bin/binary>>.

encode(Cmd, Bin) ->
	Len = byte_size(Bin) + 4,
	<<Len:16, Cmd:16, Bin/binary>>.

decode(<<Cmd:16, 1:8, Data/binary>>) ->
	{ok, Cmd, zlib:uncompress(Data)};
decode(<<Cmd:16, 0:8, Data/binary>>) ->
	{ok, Cmd, Data}.
