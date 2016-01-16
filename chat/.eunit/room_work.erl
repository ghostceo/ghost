%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.

-module(room_work).

-behaviour(gen_server).

-include("common.hrl").
%% --------------------------------------------------------------------
%% External	exports
%% --------------------------------------------------------------------
-export([start_link/1]).

%% --------------------------------------------------------------------
%% gen_server callbacks
%% --------------------------------------------------------------------
-export([init/1, handle_call/3, handle_cast/2, handle_info/2,
         terminate/2, code_change/3]).

%% ====================================================================
%% External	functions
%% ====================================================================
start_link(Name) ->
	gen_server:start_link({local, Name}, ?MODULE, [], []).

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
	{ok, []}.

%% --------------------------------------------------------------------
%% Function: handle_cast/2
%% Description:	Handling cast messages
%% Returns:	{noreply, State}		  |
%%			{noreply, State, Timeout} |
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

handle_info(_Info, State) ->{noreply, State}.
terminate(_Reason, _State) ->ok.
code_change(_OldVsn, State, _Extra) ->
    {ok, State}.
%% ====================================================================
%% Internal functions
%% ====================================================================
send_msg(Sockets, Len, Msg) ->
    lists:foreach(
        fun( {_,_UserId, Socket} ) ->
			gen_tcp:send(Socket, <<Len:16>>),
            gen_tcp:send(Socket, Msg)
        end, Sockets).

do_call({outroom, UserId, RoomNum},_From, State) ->
	io:format("~s leave ~s~n", [UserId,RoomNum]),
	{ok, Len, Data} =tcp_protocol:server_pack(14000, [UserId, RoomNum]),
	lists:foreach(
	  fun( {_UserId, Sock} ) ->
			  gen_tcp:send(Sock, <<Len:16>>),
			  gen_tcp:send(Sock, Data)
	  end, State),
	{_, Socket} = lists:keyfind(UserId, 1, State),
	New_State = lists:keydelete(UserId, 1, State),
	io:format("room member: ~n~p~n",[New_State]),
	{reply, Socket, New_State}.

do_cast({toroom, RoomNum, UserId, Socket}, State) ->
	io:format("~s entered to ~s~n",[UserId,RoomNum]),
	{ok, Len, Data} = tcp_protocol:server_pack(12000, [UserId, RoomNum]),
	New_State = [{normal, UserId, Socket} | State],
	io:format("room member: ~n~p~n",[New_State]),
	lists:foreach(
	  fun( {_, _UserId, Sock} ) ->
			  gen_tcp:send(Sock, <<Len:16>>),
			  gen_tcp:send(Sock, Data)
	  end, New_State),
	{noreply, New_State};
do_cast({outroom, UserId, RoomNum}, State) ->
	io:format("~s leave ~s~n", [UserId,RoomNum]),
	{ok, Len, Data} =tcp_protocol:server_pack(14000, [UserId, RoomNum]),
	lists:foreach(
	  fun( {_, _UserId, Sock} ) ->
			  gen_tcp:send(Sock, <<Len:16>>),
			  gen_tcp:send(Sock, Data)
	  end, State),
	New_State = lists:keydelete(UserId, 2, State),
	io:format("room member: ~n~p~n",[New_State]),
	{noreply, New_State};
do_cast({mssg, UserId, Mssg}, State) ->
	case lists:keyfind(UserId, 2, State) of
		false->
			skip,
			{noreply, State};
		{silent, _, _} ->
			Silent_Msg = "***********",
			{ok, Len, Data} = tcp_protocol:server_pack(13000, [UserId, Silent_Msg]),
			send_msg(State, Len, Data),
			{noreply, State};
		{normal, _UserId, _Socket}->
			{ok, Len, Data} = tcp_protocol:server_pack(13000, [UserId, Mssg]),
			send_msg(State, Len, Data),
			{noreply, State}
	end;	
do_cast({silence, UserId}, State) ->
	case lists:keyfind(UserId, 2, State) of
		false->
			skip,
			{noreply, State};
		{silent, _, _} ->
			skip,
			{noreply, State};
		{normal, _UserId, Socket}->
			New_State = lists:keyreplace(UserId, 2, State, {silent, UserId, Socket}),
			io:format("~p was set silent.~n",[UserId]),
			{noreply, New_State}
	end;	
do_cast({unsilence, UserId}, State) ->
	case lists:keyfind(UserId, 2, State) of
		false->
			skip,
			{noreply, State};
		{silent, _, Socket} ->
			New_State = lists:keyreplace(UserId, 2, State, {normal, UserId, Socket}),
			io:format("~p was set unsilent.~n",[UserId]),
			{noreply, New_State};
		{normal, _, _}->
			skip,
			{noreply, State}
	end;	
do_cast({disconnect, UserId, RoomNum}, State) ->
	io:format("~s disconnect ~s~n", [UserId,RoomNum]),
	{ok, Len, Data} =tcp_protocol:server_pack(15000, [UserId, RoomNum]),
	lists:foreach(
	  fun( {_, _UserId, Sock} ) ->
			  gen_tcp:send(Sock, <<Len:16>>),
			  gen_tcp:send(Sock, Data)
	  end, State),
	New_State = lists:keydelete(UserId, 1, State),
	io:format("room member: ~n~p~n",[New_State]),
	{noreply, New_State}.
