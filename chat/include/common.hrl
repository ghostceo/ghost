%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.
%% common
%% --------------------------------------------------------------------
%% Logging mechanism
%% Print in standard output
-include("proto.hrl").

-define(WARNING_MSG(Format, Args),
		logger:warning_msg(?MODULE,?LINE,Format, Args)).
-define(TCP_OPTIONS, [binary, {packet, 0}, {active, false}]).