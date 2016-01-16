%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.

-module(server_sup).

-behaviour(supervisor).
%% --------------------------------------------------------------------
%% Include files
%% --------------------------------------------------------------------

%% --------------------------------------------------------------------
%% External	exports
%% --------------------------------------------------------------------
-export([start_link/0]).

%% --------------------------------------------------------------------
%% Internal	exports
%% --------------------------------------------------------------------
-export([init/1]).

%% ====================================================================
%% External	functions
%% ====================================================================
%% @doc	Start supervisor link.
start_link() ->
    supervisor:start_link({local, ?MODULE}, ?MODULE, []).
	
%% ====================================================================
%% Supervisor callbacks
%% ====================================================================
%% --------------------------------------------------------------------
%% Func: init/1
%% Returns:	{ok,  {SupFlags,  [ChildSpec]}}	|
%%			ignore							|
%%			{error,	Reason}
%% --------------------------------------------------------------------
init([]) ->
	{ok, {
            {one_for_one, 3, 10}, 
            [{room_sup,
			  {room_sup, start_link, []},
			  permanent,
			  1000,
			  supervisor,
			  [room_sup]
			  },
			 {ben,
			  {ben, start_link, []},
			  transient,
			  1000,
			  worker,
			  [ben]
			  },
			 {listen_work,
			  {listen_work, start_link, []},
			  transient,
			  1000,
			  worker,
			  [listen_work]
			  },
			  {user_manager,
			  {user_manager, start_link, []},
			  transient,
			  1000,
			  worker,
			  [user_manager]
			  },
			 {room_manager,
			  {room_manager, start_link, []},
			  transient,
			  1000,
			  worker,
			  [room_manager]
			  }]
	}}.

