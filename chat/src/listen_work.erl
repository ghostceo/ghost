%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.

-module(listen_work).

-behaviour(gen_server).

-include("common.hrl").

%% ---------------------------------------------------------------------
%% External	exports
%% ---------------------------------------------------------------------
-export([start_link/0]).

%% --------------------------------------------------------------------
%% gen_server callbacks
%% --------------------------------------------------------------------
-export([init/1, handle_call/3, handle_cast/2, handle_info/2,
         terminate/2, code_change/3]).

%% ====================================================================
%% External	functions
%% ====================================================================
start_link() ->
	gen_server:start_link({local, ?MODULE}, ?MODULE, [443], []).

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
init([Port]) ->
	erlang:process_flag(trap_exit, true),
	try
		do_init([Port])
	catch
		_:Reason ->
			%?WARNING_MSG("do_init has exception:~w~n",[Reason]),
			%?WARNING_MSG("get_stacktrace:~p",[erlang:get_stacktrace()]),
			{ok, 0}
	end.

handle_call(_Request, _From, State) -> {noreply, State}.
handle_cast(_Msg, State) -> {noreply, State}.	
handle_info(_Info, State) -> {noreply, State}.
terminate(_Reason, _State) -> ok.
code_change(_OldVsn, State, _Extra) -> {ok, State}.

%% ====================================================================
%% Internal functions
%% ====================================================================
%%  Listen for connection of the clients.
%%	Create a Socket for accept message from the client.
loop_listen(Listen)->
	case gen_tcp:accept(Listen) of
		{ok, Socket} ->
			%%?WARNING_MSG("listened :~p~n",[Socket]),
			spawn(fun()->loop_accept(Socket, 0)end );
		{error, Reason} ->
			?WARNING_MSG("~p~n",[Reason])
    end,
	loop_listen(Listen).

loop_accept(Socket, UserPID) ->
	case gen_tcp:recv(Socket, 2) of	
		{ok, <<Len:16>>} ->
		%{ok, R}  ->
			io:format("~p~n",[Len]),
			case gen_tcp:recv(Socket, Len) of
				{ok,<<R:32>>}->
					io:format("~p~n",[R]);
				{ok, <<?CS_REGISTER:16, Len1:16, Bin/binary>>} -> 
					<<Regid:Len1/binary-unit:8,_Len2:16, Password/binary>> = Bin,
					RegId = binary_to_list(Regid), 
					gen_server:cast(user_manager, {reg, RegId, Password, Socket}),
					loop_accept(Socket, UserPID);
				{ok, <<?CS_LOGIN:16, Len1:16, Bin/binary>>} ->  
					<<Logid:Len1/binary-unit:8,_Len2:16, Password/binary>> = Bin,
					UserId = binary_to_list(Logid), 
					Userpid = erlang:spawn_link(fun() -> user_handle(UserId, Password, Socket) end),
					loop_accept(Socket, Userpid);
				{ok, <<?CS_CHOOSE_ROOM:16, Bin/binary>>} ->
					RoomNum = binary_to_list(Bin),
					gen_server:cast(user_manager, {enter_room, RoomNum, UserPID, Socket}),
					loop_accept(Socket, UserPID);
				{ok, <<?CS_SEND_MSG:16, Bin/binary>>} ->
					Msg = binary_to_list(Bin),
					case ets:lookup(roomdata, UserPID)of
						[{_, {RoomNum, UserId}}] ->
							gen_server:cast(room_manager, {msg, RoomNum, UserId, Msg}),
							loop_accept(Socket, UserPID);
						[]->
							gen_tcp:send(Socket, <<1:16>>),
							gen_tcp:send(Socket, <<2>>),
							loop_accept(Socket, UserPID)
					end;		
				{ok,<<?CS_LEAVE_ROOM:16, Bin/binary>>} ->
					case Bin of
						<<1>> ->
							gen_server:cast(user_manager, {leave_room, UserPID})
					end,
					loop_accept(Socket, UserPID);		
				{ok,<<?CS_LOGOUT:16, Bin/binary>>} ->
					case Bin of
						<<1>> ->
							gen_server:cast(user_manager, {logout, UserPID, Socket})
					end,
					loop_accept(Socket, UserPID);
				{ok, <<?CS_ADD_ROOM:16, Bin/binary>>} ->
					RoomName = binary_to_list(Bin),
					gen_server:cast(room_manager, {add_room, RoomName, Socket}),
					loop_accept(Socket, UserPID);
				{ok, <<?CS_DELETE_ROOM:16, Bin/binary>>} ->
					RoomName = binary_to_list(Bin),
					gen_server:cast(room_manager, {delete_room, RoomName, Socket}),
					loop_accept(Socket, UserPID);
				{ok, <<?CS_MOVE_A_USER:16, Len1:16, Bin/binary>>} ->  
					<<Userid:Len1/binary-unit:8,_Len2:16, Room/binary>> = Bin,
					UserId = binary_to_list(Userid), 
					RoomName = binary_to_list(Room),
					gen_server:cast(user_manager, {move, UserId, RoomName, Socket}),
					loop_accept(Socket, UserPID);
				{ok, <<?CS_MOVE_ALL_USER:16, Len1:16, Bin/binary>>} ->  
					<<Room1:Len1/binary-unit:8,_Len2:16, Room2/binary>> = Bin,
					ExRoom = binary_to_list(Room1), 
					NowName = binary_to_list(Room2),
					gen_server:cast(user_manager, {move_all, UserPID, ExRoom, NowName, Socket}),
					loop_accept(Socket, UserPID);
				{ok, <<?CS_SILENT_USER:16, Bin/binary>>} ->
					UserId = binary_to_list(Bin),
					gen_server:cast(user_manager, {silence, UserId, Socket}),
					loop_accept(Socket, UserPID);
				{ok, <<?CS_UNSILENT_USER:16, Bin/binary>>} ->
					UserId = binary_to_list(Bin),
					gen_server:cast(user_manager, {unsilence, UserId, Socket}),
					loop_accept(Socket, UserPID);
				{error, Reason} ->
					%?WARNING_MSG("~p~n",[Reason])
					io:format("~p~n",[Reason])
			end;
		{error, closed} ->
			gen_server:cast(user_manager, {disconnect, UserPID, Socket})
	end.

user_handle(UserId, Password, Socket) ->
	UserPID = self(),
	gen_server:cast(user_manager, {login, UserId, Password, UserPID, Socket}),
	ok.
do_init([Port]) ->
	case gen_tcp:listen(Port, ?TCP_OPTIONS) of
        {ok, Listen} ->
            spawn_link(fun() ->loop_listen(Listen) end);
        {error, Reason} ->
             ?WARNING_MSG("~p~n",[Reason])
    end,
	{ok, 0}.