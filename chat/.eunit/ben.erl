%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.

-module(ben).

-behaviour(gen_server).

-export([init/1, handle_call/3, handle_cast/2, handle_info/2,
         terminate/2, code_change/3]).

%% --------------------------------------------------------------------
%% External	exports
%% --------------------------------------------------------------------
-export([start_link/0]).

%% @doc	Start a monitored process.
start_link() ->
	gen_server:start_link({local, ?MODULE}, ?MODULE, [], []).

%% 	Create an ets list for online data.
%%	Create another ets list for room data.
init([]) ->
	erlang:process_flag(trap_exit, true),
	ets:new(onlinedata, [duplicate_bag, public, named_table, {keypos, 1}]),
	ets:new(roomdata, [duplicate_bag, public, named_table, {keypos, 1}]),
	{ok, 0}.

handle_call(_Request, _From, State) ->
    {noreply, State}.
handle_cast(_Msg, State) ->{noreply, State}.	
handle_info(_Info, State) ->{noreply, State}.
terminate(_Reason, _State) ->ok.
code_change(_OldVsn, State, _Extra) ->
    {ok, State}.