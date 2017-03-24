%%%===================================================================
%%% @author z.hua
%%% @doc
%%%
%%% @end
%%%===================================================================

-module(pressure_sup).

-behaviour(supervisor).

%% supervisor callbacks
-export([init/1]).
%% API
-export([start_link/0]).

-define(SERVER, ?MODULE).

%%%-------------------------------------------------------------------
%%% API Functions
%%%-------------------------------------------------------------------
start_link() ->
	supervisor:start_link({local, ?SERVER}, ?MODULE, {}).

%%%-------------------------------------------------------------------
%%% Callback Functions
%%%-------------------------------------------------------------------
init(_Args) ->
	{ok, Scenes} = application:get_env(scenes),
	{ok, Load}   = application:get_env(load),
    pressure_agent:new_table(),
	{_, ChildSpecs} = lists:foldl(fun
		({SceneID, X, Y}, {AccGrp, AccList}) ->
			AccList2 = lists:foldl(fun
				(N, AccListIn) ->
					RoleID = AccGrp * 100 + N,
					Spec = #{
						id       => {pressure_agent, RoleID},
						start    => {pressure_agent, start_link, [RoleID, SceneID, X, Y]},
						restart  => permanent,
						shutdown => 5000,
						type     => worker,
						modules  => [pressure_agent]
					},
					[Spec | AccListIn]
			end, AccList, lists:seq(1, Load)),
			{AccGrp + 1, AccList2}
	end, {1, []}, Scenes),
	SupFlags = #{
		strategy  => one_for_one,
		intensity => 10,
		period    => 5
	},
    {ok, {SupFlags, ChildSpecs}}.
