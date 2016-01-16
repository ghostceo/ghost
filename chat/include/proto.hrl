%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.
%% proto
%%-------------------------------------------------------
%% User to server request
%%-------------------------------------------------------
-define(CS_REGISTER,						10000).
-define(CS_LOGIN,							11000).
-define(CS_CHOOSE_ROOM,						12000).
-define(CS_SEND_MSG,						13000).
-define(CS_LEAVE_ROOM,						14000).
-define(CS_LOGOUT,							15000).

%%-------------------------------------------------------
%% Admin to server request
%%-------------------------------------------------------
-define(CS_ADD_ROOM,						16000).
-define(CS_DELETE_ROOM,						17000).
-define(CS_MOVE_A_USER,						18000).
-define(CS_MOVE_ALL_USER,					19000).
-define(CS_SILENT_USER,						20000).
-define(CS_UNSILENT_USER,					21000).

%%-------------------------------------------------------
%% server to user response
%%-------------------------------------------------------
-define(SC_REGISTER_REPLY,					10000).
-define(SC_LOGIN_REPLY,						11000).
-define(SC_CHOOSE_ROOM_REPLY,				12000).
-define(SC_BROADCAST_MSG,					13000).
-define(SC_LEAVE_ROOM_REPLY,				14000).
-define(SC_DISCONNECT,						15000).
-define(SC_NEW_ADDED_ROOM_NAME,				16000).
-define(SC_NEW_DELETED_ROOM_NAME,			17000).
