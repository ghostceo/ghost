%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.

-module(tcp_protocol).

-include("common.hrl").
%%================================================
%% Exported Functions
%%================================================
-export([client_pack/2, server_pack/2]).

%%================================================
%%protocol of client's pack
%%================================================
client_pack(?CS_REGISTER, [Id, Password]) ->
    Data1 = list_to_binary(Id),
	Len1 = byte_size(Data1),
	Len2 = byte_size(Password),
    Data = <<?CS_REGISTER:16, Len1:16, Data1/binary, 
			 Len2:16, Password/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_LOGIN, [Id, Password]) ->
    Data1 = list_to_binary(Id),
	Len1 = byte_size(Data1),
	Len2 = byte_size(Password),
    Data = <<?CS_LOGIN:16, Len1:16, Data1/binary, 
			 Len2:16, Password/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_CHOOSE_ROOM, RoomNum) ->
    Room = list_to_binary(RoomNum),
    Data = <<?CS_CHOOSE_ROOM:16, Room/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_SEND_MSG, Msg) ->
    Msgt = list_to_binary(Msg),
    Data = <<?CS_SEND_MSG:16, Msgt/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_LEAVE_ROOM, LMsg) ->
    Data = <<?CS_LEAVE_ROOM:16, LMsg/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_LOGOUT, LogMsg) ->
    Data = <<?CS_LOGOUT:16, LogMsg/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_ADD_ROOM, RoomName) ->
    Room = list_to_binary(RoomName),
    Data = <<?CS_ADD_ROOM:16, Room/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_DELETE_ROOM, RoomName) ->
    Room = list_to_binary(RoomName),
    Data = <<?CS_DELETE_ROOM:16, Room/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_MOVE_A_USER, [UserId, RoomName]) ->
    Data1 = list_to_binary(UserId),
	Len1 = byte_size(Data1),
	Data2 = list_to_binary(RoomName),
	Len2 = byte_size(Data2),
    Data = <<?CS_MOVE_A_USER:16, Len1:16, Data1/binary, 
			 Len2:16, Data2/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_MOVE_ALL_USER, [Room1, Room2]) ->
    Data1 = list_to_binary(Room1),
	Len1 = byte_size(Data1),
	Data2 = list_to_binary(Room2),
	Len2 = byte_size(Data2),
    Data = <<?CS_MOVE_ALL_USER:16, Len1:16, Data1/binary, 
			 Len2:16, Data2/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_SILENT_USER, UserId) ->
    Userid = list_to_binary(UserId),
    Data = <<?CS_SILENT_USER:16, Userid/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
client_pack(?CS_UNSILENT_USER, UserId) ->
    Userid = list_to_binary(UserId),
    Data = <<?CS_UNSILENT_USER:16, Userid/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data}.

%%================================================
%%protocol of server's pack
%%================================================
-spec server_pack(integer(), list()) -> 
		  {ok, integer, binary}.
%% @doc 10000:Pack the result of register;
%%		11000:Pack the result of login request;
%% 		12000:Pack the result of choose room request;
%% 		13000:Pack the message for broadcasting;
%% 		14000:Pack the result of leave room request;
%% 		15000:Pack the disconnect message;
%%		16000:Pack the new_added Room Name;
%%		17000:Pack the new_delete Room Name;
server_pack(?SC_REGISTER_REPLY, RegRe) ->
    Data = <<?SC_REGISTER_REPLY:16, RegRe/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
server_pack(?SC_LOGIN_REPLY, LoginRe) ->
	Stat = list_to_binary(LoginRe),
    Data = <<?SC_LOGIN_REPLY:16, Stat/binary>>,
	Len = byte_size(Data),
	{ok, Len, Data};
server_pack(?SC_CHOOSE_ROOM_REPLY, [UserId, RoomNum]) ->
	Userid = list_to_binary(UserId),
	Len1 = byte_size(Userid),
	Roomnum = list_to_binary(RoomNum),
	Len2 = byte_size(Roomnum),
	Data = <<?SC_CHOOSE_ROOM_REPLY:16, Len1:16, Userid/binary, 
			 Len2:16, Roomnum/binary>>,
	Len = byte_size(Data),
	{ok, Len, Data};
server_pack(?SC_BROADCAST_MSG, [UserId, Msg]) ->
    Userid = list_to_binary(UserId),
    Len1 = byte_size(Userid),
    Msgt = list_to_binary(Msg),
    Len2 = byte_size(Msgt),
    Data = <<?SC_BROADCAST_MSG:16, Len1:16, Userid/binary, 
			 Len2:16, Msgt/binary>>,
	Len = byte_size(Data),
    {ok, Len, Data};
server_pack(?SC_LEAVE_ROOM_REPLY, [UserId, RoomNum]) ->
	Userid = list_to_binary(UserId),
	Len1 = byte_size(Userid),
	Roomnum = list_to_binary(RoomNum),
	Len2 = byte_size(Roomnum),
	Data = <<?SC_LEAVE_ROOM_REPLY:16, Len1:16, Userid/binary, 
			 Len2:16, Roomnum/binary>>,
	Len = byte_size(Data),
	{ok, Len, Data};
server_pack(?SC_DISCONNECT, [UserId, RoomNum]) ->
	Userid = list_to_binary(UserId),
	Len1 = byte_size(Userid),
	Roomnum = list_to_binary(RoomNum),
	Len2 = byte_size(Roomnum),
	Data = <<?SC_DISCONNECT:16, Len1:16, Userid/binary, 
			 Len2:16, Roomnum/binary>>,
	Len = byte_size(Data),
	{ok, Len, Data};
server_pack(?SC_NEW_ADDED_ROOM_NAME, RoomName) ->
	Stat = list_to_binary(RoomName),
    Data = <<?SC_NEW_ADDED_ROOM_NAME:16, Stat/binary>>,
	Len = byte_size(Data),
	{ok, Len, Data};
server_pack(?SC_NEW_DELETED_ROOM_NAME, RoomName) ->
	Stat = list_to_binary(RoomName),
    Data = <<?SC_NEW_DELETED_ROOM_NAME:16, Stat/binary>>,
	Len = byte_size(Data),
	{ok, Len, Data}.
