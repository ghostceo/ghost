%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.

-module(room_manager).

-behaviour(gen_server).

-include("common.hrl").
%% --------------------------------------------------------------------
%% External	exports
%% --------------------------------------------------------------------
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

do_cast({add_room, RoomName, Socket}, State) ->
	case lists:member(RoomName, State) of
		true ->
			skip;
		false ->
			New_Rooms = [RoomName|State],
			Name = list_to_atom(RoomName),
			add_room(Name),
			{ok, Len, Data} = tcp_protocol:server_pack(16000, RoomName),  
			gen_tcp:send(Socket, <<Len:16>>),
			gen_tcp:send(Socket, Data),
			{noreply, New_Rooms}
	end;
do_cast({delete_room, RoomName, Socket}, State) ->
	case lists:member(RoomName, State)of
		false ->
			skip,
			{noreply, State};
		true ->
			New_Rooms = lists:delete(RoomName, State),
			Name = list_to_atom(RoomName),
			delete_room(Name),
			{ok, Len, Data} = tcp_protocol:server_pack(17000, RoomName),  
			gen_tcp:send(Socket, <<Len:16>>),
			gen_tcp:send(Socket, Data),
			{noreply, New_Rooms}
	end;

do_cast({research, UserId, Socket}, State) ->
	lists:foreach(
	  fun(Room)->
			  {ok, Len, Data} = tcp_protocol:server_pack(16000, Room),  
			  gen_tcp:send(Socket, <<Len:16>>),
			  gen_tcp:send(Socket, Data)
	  end, State),
	{ok, Len, Data} = tcp_protocol:server_pack(11000, UserId),
	gen_tcp:send(Socket, <<Len:16>>),
	gen_tcp:send(Socket, Data),
	{noreply, State};
do_cast({inroom, RoomNum, UserId, Socket}, State) ->
	io:format("~p~n",[RoomNum]),
	io:format("~p~n",[State]),
	case lists:member(RoomNum, State)of
		false ->skip;
		true ->
			Name1 = list_to_atom(RoomNum),
			gen_server:cast(Name1, {toroom, RoomNum, UserId, Socket})
	end,
	{noreply, State};
do_cast({msg, RoomNum, UserId, Msg}, State) ->
	case lists:member(RoomNum, State)of
		false ->skip;
		true ->
			Name1 = list_to_atom(RoomNum),
			gen_server:cast(Name1, {mssg, UserId, Msg})
	end,
	{noreply, State};
do_cast({outroom, RoomNum, UserId}, State) ->
	case lists:member(RoomNum, State)of
		false ->skip;
		true ->
			Name1 = list_to_atom(RoomNum),
			gen_server:cast(Name1, {outroom, UserId, RoomNum})
	end,
	{noreply, State};
do_cast({disconnect, RoomNum, UserId}, State) ->
	case lists:member(RoomNum, State)of
		false ->skip;
		true ->
			Name1 = list_to_atom(RoomNum),
			gen_server:cast(Name1, {disconnect, UserId, RoomNum})
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
terminate(_Reason, _State) ->ok.
%% --------------------------------------------------------------------
%% Func: code_change/3
%% Purpose:	Convert	process	state when code	is changed
%% Returns:	{ok, NewState}
%% --------------------------------------------------------------------
code_change(_OldVsn, State, _Extra) ->{ok, State}.
%% ====================================================================
%% Internal functions
%% ====================================================================
add_room(Name)->
	supervisor:start_child(room_sup, 
						   {"Name", {room_work, start_link, [Name]},
							transient, 1000, worker, [room_sup]}).
delete_room(Name) ->
	supervisor:delete_child(room_sup, Name).

do_init([]) ->
	Name = "room1",
	Name1 = list_to_atom(Name),
	supervisor:start_child(room_sup, 
						   {Name, {room_work, start_link, [Name1]},
							transient, 1000, worker, [room_sup]}),
	{ok, [Name]}.

do_call({outroom, RoomNum, UserId},_From,	State) ->
	case lists:member(RoomNum, State)of
		false ->skip;
		true ->
			Name1 = list_to_atom(RoomNum),
			Reply = gen_server:call(Name1, {outroom, UserId, RoomNum}),
			{reply, Reply, State}
	end.



