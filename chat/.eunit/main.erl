%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.

-module(main).

%% --------------------------------------------------------------------
%% Include files
%% --------------------------------------------------------------------
%-include_lib("stdlib/include/ms_transform.hrl").

%-ifdef(TEST).
%-include_lib("eunit/include/eunit.hrl").
%-endif.

-define(SERVER_APPS, [sasl, server]).

%% --------------------------------------------------------------------
%% Exported Functions 
%% --------------------------------------------------------------------
-export([
		 server_start/0,
		 server_stop/0,
		 info/0
		]).

%% ====================================================================
%% API Functions
%% ====================================================================
server_start()->
    try
        ok = start_applications(?SERVER_APPS)
    after
        timer:sleep(100)
    end.

server_stop() ->
    ok = stop_applications(?SERVER_APPS),
    ok.

info() ->
    SchedId      = erlang:system_info(scheduler_id),
    SchedNum     = erlang:system_info(schedulers),
    ProcCount    = erlang:system_info(process_count),
    ProcLimit    = erlang:system_info(process_limit),
    ProcMemUsed  = erlang:memory(processes_used),
    ProcMemAlloc = erlang:memory(processes),
    MemTot       = erlang:memory(total),
    io:format( "abormal termination:
                       ~n   Scheduler id:                         ~p
                       ~n   Num scheduler:                        ~p
                       ~n   Process count:                        ~p
                       ~n   Process limit:                        ~p
                       ~n   Memory used by erlang processes:      ~p
                       ~n   Memory allocated by erlang processes: ~p
                       ~n   The total amount of memory allocated: ~p
                       ~n",
                            [SchedId, SchedNum, ProcCount, ProcLimit,
                             ProcMemUsed, ProcMemAlloc, MemTot]),
      ok.

%% ====================================================================
%% Local Functions
%% ====================================================================
manage_applications(Iterate, Do, Undo, SkipError, ErrorTag, Apps) ->
    Iterate(fun (App, Acc) ->
                    case Do(App) of
                        ok -> [App | Acc];
                        {error, {SkipError, _}} -> Acc;
                        {error, Reason} ->
                            lists:foreach(Undo, Acc),
                            throw({error, {ErrorTag, App, Reason}})
                    end
            end, [], Apps),
    ok.

start_applications(Apps) ->
    manage_applications(fun lists:foldl/3,
                        fun application:start/1,
                        fun application:stop/1,
                        already_started,
                        cannot_start_application,
                        Apps).

stop_applications(Apps) ->
    manage_applications(fun lists:foldr/3,
                        fun application:stop/1,
                        fun application:start/1,
                        not_started,
                        cannot_stop_application,
                        Apps).


%% ====================================================================
%% Test Functions
%% ====================================================================
-ifdef(TEST).
main_test_() ->
	{timeout, 60, ?_assertEqual(ok, test_main())}.

test_main() ->
	server_start(),
	info(),
	server_stop(),
	ok.
-endif.
