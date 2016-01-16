%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.

-module(user_manager).

-behaviour(gen_server).

-include("common.hrl").
%% --------------------------------------------------------------------
%% External	exports
%% --------------------------------------------------------------------
-export([start_link/0, add_admin/1]).

%% --------------------------------------------------------------------
%% gen_server callbacks
%% --------------------------------------------------------------------
-export([init/1, handle_call/3, handle_cast/2, handle_info/2,
         terminate/2, code_change/3]).
%% ====================================================================
%% External	functions
%% ====================================================================
start_link() ->
	gen_server:start_link({local, ?MODULE}, ?MODULE, [], []).

%% ====================================================================
%% Server functions
%% ====================================================================

%% --------------------------------------------------------------------
%% Function: init/1
%% Description:	Initiates the server
%% Returns:	{ok, State}			 |
%%			{ok, State,	Timeout} |
%%			ignore				 |
%%			{stop, Reason}
%% --------------------------------------------------------------------
init([]) ->
	erlang:process_flag(trap_exit, true),
	try
		do_init([])
	catch
		_:Reason ->
			?WARNING_MSG("do_init has exception:~w~n",[Reason]),
			?WARNING_MSG("get_stacktrace:~p",[erlang:get_stacktrace()]),
			{ok, 0}
	end.
%% --------------------------------------------------------------------
%% Function: handle_call/3
%% Description:	Handling call messages
%% Returns:	{reply,	Reply, State}		   |
%%			{reply,	Reply, State, Timeout} |
%%			{noreply, State}			   |
%%			{noreply, State, Timeout}	   |
%%			{stop, Reason, Reply, State}   | (terminate/2 is called)
%%			{stop, Reason, State}			 (terminate/2 is called)
%% --------------------------------------------------------------------
handle_call(Info, _From, State) ->
	try
		do_call(Info,_From,	State)
	catch
		_:Reason ->
			?WARNING_MSG("user_manager handle_call is exception:~w~n,Info:~w",[Reason,	Info]),
			?WARNING_MSG("get_stacktrace:~p",[erlang:get_stacktrace()]),
			{reply,	ok,	State}
	end.

%% --------------------------------------------------------------------
%% Function: handle_cast/2
%% Description:	Handling cast messages
%% Returns:	{noreply, State}		  |
%%			{noreply, State, Timeout} |
%%			{stop, Reason, State}			 (terminate/2 is called)
%% --------------------------------------------------------------------
handle_cast(Info, State) ->
	try
		do_cast(Info, State)
	catch
		_:Reason ->
			?WARNING_MSG("user_manager handle_cast is exception:~w~n,Info:~w",[Reason, Info]),
			?WARNING_MSG("get_stacktrace:~p",[erlang:get_stacktrace()]),
			{noreply, State}
	end.
	
%% --------------------------------------------------------------------
%% Function: handle_info/2
%% Description:	Handling all non call/cast messages
%% Returns:	{noreply, State}		  |
%%			{noreply, State, Timeout} |
%%			{stop, Reason, State}			 (terminate/2 is called)
%% --------------------------------------------------------------------
handle_info(_Info, State) ->{noreply, State}.
%% --------------------------------------------------------------------
%% Function: terminate/2
%% Description:	Shutdown the server
%% Returns:	any	(ignored by	gen_server)
%% --------------------------------------------------------------------
terminate(Info, Status) ->
	try
		do_terminate(Info, Status)
	catch
		_:Reason ->
			?WARNING_MSG("user_manager terminate is exception:~w~n",[Reason]),
			?WARNING_MSG("get_stacktrace:~p",[erlang:get_stacktrace()]),
			ok
	end.
%% --------------------------------------------------------------------
%% Func: code_change/3
%% Purpose:	Convert	process	state when code	is changed
%% Returns:	{ok, NewState}
%% --------------------------------------------------------------------
code_change(_OldVsn, State, _Extra) ->
    {ok, State}.
%% ====================================================================
%% Internal functions
%% ====================================================================
check_user(UserId, Password, UserList) ->
	case lists:keyfind(UserId, 2, UserList) of
		false ->
			{error, not_a_user };
		{user, _User, Pass} ->
			case Pass == Password of
				false->
					{error, wrong_password};
				true ->
					{ok, user}
			end;
		{admin, _User, Pass} ->
			case Pass == Password of
				false->
					{error, wrong_password};
				true ->
					{ok, admin}
			end
	end.
	
add_admin(UserId)->
	gen_server:cast(?MODULE, {add_admin, UserId}),
	ok.

do_init([]) ->
	{ok, UserList} = file:consult("reg_data"),
	{ok, UserList}.

do_call(_Info,_From,	State) ->{reply, ok, State}.

do_cast({reg, RegId, Password, Socket}, State) ->
	case check_user(RegId, "_", State)of
		{error, not_a_user}->
			New_List = [{user, RegId, Password}|State],
			{ok, Len, Data} = tcp_protocol:server_pack(10000, <<1>>),
			gen_tcp:send(Socket, <<Len:16>>),
			gen_tcp:send(Socket, Data),
			{noreply, New_List};
		{error, wrong_password} ->
			gen_tcp:send(Socket, <<1:16>>),
			gen_tcp:send(Socket, <<4>>),
			{noreply, State};
		{ok, _UserId}->
			gen_tcp:send(Socket, <<1:16>>),
			gen_tcp:send(Socket, <<4>>),
			{noreply, State}
	end;
do_cast({login, UserId, Password, UserPID, Socket}, State) ->
	case check_user(UserId, Password , State) of
		{error, not_a_user} -> 
			gen_tcp:send(Socket, <<1:16>>),
			gen_tcp:send(Socket, <<0>>),
			{noreply, State};
		{error, wrong_password} ->
			gen_tcp:send(Socket, <<1:16>>),
			gen_tcp:send(Socket, <<3>>),
			{noreply, State};
		{ok, user} ->    
			?WARNING_MSG("User ~s login~n", [UserId]),
			ets:insert(onlinedata, {UserPID, {user, UserId}}),
			gen_server:cast(room_manager, {research, UserId, Socket}),
			{noreply, State};
		{ok, admin} ->
			?WARNING_MSG("Admin ~s login~n", [UserId]),
			ets:insert(onlinedata, {UserPID, {admin, UserId}}),
			gen_server:cast(room_manager, {research, UserId, Socket}),
			{noreply, State}
	end;
do_cast({enter_room, RoomNum, UserPID, Socket}, State) ->
	case ets:lookup(onlinedata, UserPID)of 
		[{_, {_, UserId}}]->
			gen_server:cast(room_manager, {inroom, RoomNum, UserId, Socket}),
			ets:insert(roomdata, {UserPID, {RoomNum, UserId}}),
			{noreply, State};
		[]->
			gen_tcp:send(Socket, <<1:16>>),
			gen_tcp:send(Socket, <<1>>),
			{noreply, State}
	end;
do_cast({leave_room, UserPID}, State) ->
	[{_, {RoomNum, UserId}}] = ets:lookup(roomdata, UserPID),
	gen_server:cast(room_manager, {outroom, RoomNum, UserId}),
	ets:delete(roomdata, UserPID),
	{noreply, State};
do_cast({logout, UserPID, Socket}, State) ->
	[{_, {_, UserId}}] = ets:lookup(onlinedata, UserPID),
	?WARNING_MSG("~s logout ~n",[UserId]),
	ets:delete(onlinedata, UserPID),
	gen_tcp:send(Socket, <<1:16>>),
	gen_tcp:send(Socket, <<5>>),
	{noreply, State};
do_cast({disconnect, UserPID, Socket}, State) ->
	case ets:lookup(roomdata, UserPID)of 
		[{_, {RoomNum, UserId}}] ->
			gen_server:cast(room_manager, {disconnect, RoomNum, UserId}),
			{noreply, State};
		[]->
			case ets:lookup(onlinedata, UserPID)of 
				[{_, {_, UserId}}]->
					?WARNING_MSG("~s disconnect.~n",[UserId]),
					{noreply, State};
				[]->
					?WARNING_MSG("~p disconnect.~n",[Socket]),
					{noreply, State}
			end
	end;
do_cast({add_admin, UserId}, State) ->
	case lists:keyfind(UserId, 2, State) of
		false->
			?WARNING_MSG("~p is not a user,sorry.~n",[UserId]),
			{noreply, State};
		{admin, _User, _Pass}->
			?WARNING_MSG("~p is already a admin.~n",[UserId]),
			{noreply, State};
		{user, User, Pass} ->
			New_List = lists:keyreplace(User, 2, State, {admin, User, Pass}),
			{noreply, New_List}
	end;
do_cast({move, UserId, RoomName, Socket}, State) ->
	case lists:keyfind(UserId, 2, State) of
		false ->
			?WARNING_MSG("~p is not a user,sorry.~n",[UserId]),
			{noreply, State};
		{admin, _User, _Pass}->
			[{UserPID, {Used_Room, _UserId}}] = ets:match_object(roomdata, 
																 {'_', {'_', UserId}}),
			case gen_server:call(room_manager, {outroom, Used_Room, UserId})of
				Socket->
					ets:delete(roomdata, UserPID),
					gen_server:cast(?MODULE, {enter_room, RoomName, UserPID, Socket})
			end,
			{noreply, State};
		{user, _User, _Pass} ->
			gen_tcp:send(Socket, <<1:16>>),
			gen_tcp:send(Socket, <<6>>),
			{noreply, State}
	end;
do_cast({move_all, UserPID, ExRoom, NowName, Socket}, State) ->
	[{_, {_, UserId}}] = ets:lookup(onlinedata, UserPID),
	case lists:keyfind(UserId, 2, State) of
		false ->
			?WARNING_MSG("~p is not a user,sorry.~n",[UserId]),
			{noreply, State};
		{admin, _User, _Pass}->
			List = ets:match_object(roomdata, {'_', {ExRoom, '_'}}),
			lists:foreach(
			  fun({_, {_, User}})->
					  gen_server:cast(?MODULE, {move, User, NowName})
			  end, 
			  List),
			{noreply, State};
		{user, _User, _Pass} ->
			gen_tcp:send(Socket, <<1:16>>),
			gen_tcp:send(Socket, <<6>>)
	end;
do_cast({silence, UserId, Socket}, State) ->
	case lists:keyfind(UserId, 2, State) of
		false ->
			?WARNING_MSG("~p is not a user,sorry.~n",[UserId]),
			{noreply, State};
		{admin, _User, _Pass}->
			[{_UserPID, {RoomName, _UserId}}] = ets:match_object(roomdata, 
																 {'_', {'_', UserId}}),
			Name1 = list_to_atom(RoomName),
			gen_server:cast(Name1, {silence, UserId}),
			{noreply, State};
		{user, _User, _Pass} ->
			gen_tcp:send(Socket, <<1:16>>),
			gen_tcp:send(Socket, <<6>>),
			{noreply, State}
	end;
do_cast({unsilence, UserId, Socket}, State) ->
	case lists:keyfind(UserId, 2, State) of
		false ->
			?WARNING_MSG("~p is not a user,sorry.~n",[UserId]),
			{noreply, State};
		{admin, _User, _Pass}->
			[{_UserPID, {RoomName, _UserId}}] = ets:match_object(roomdata, 
																 {'_', {'_', UserId}}),
			Name1 = list_to_atom(RoomName),
			gen_server:cast(Name1, {unsilence, UserId}),
			{noreply, State};
		{user, _User, _Pass} ->
			gen_tcp:send(Socket, <<1:16>>),
			gen_tcp:send(Socket, <<6>>),
			{noreply, State}
	end.

do_terminate(_Reason, {UserList, _}) ->
	{ok, S} = file:open("reg_data", write),
	lists:foreach(fun(X)-> io:format(S,"~p.~n",[X])end, UserList),
	file:close(S),
	ok.
	
	
	