%% @author Zhang Zhizhen <QQ:5256712007>
%% @since 2012-2-20
%% @copyright 2011
%% @doc	Server supervisor module.

-module(client).

-include("common.hrl").
%% --------------------------------------------------------------------
%% External	exports
%% --------------------------------------------------------------------
-export([start/0, reg_player/2, login/2, 
		 enter_room/1, leave_room/0, logout/0, 
		 said/1, send_msg/1, recv_msg/2, 
		 add_room/1, delete_room/1, move/2,
		 move_all/2, silence/1, unsilence/1]).

%% --------------------------------------------------------------------
%% Request	function
%% --------------------------------------------------------------------

-spec start() -> ok.
%% @doc Start Socket connect without parameter.
%%		Register a process for send message
%% 		Register a process for receive message
start() ->
	{ok, Socket} = gen_tcp:connect("172.27.35.4", 443,
								 [binary, 
								  {active, false}, 
								  {packet, 0}
								  ]),
	register(send_msg, 
			 spawn(fun()->send_msg(Socket)end )
			 ),
	register(recv_msg, 
			 spawn(fun()->recv_msg(Socket, [])end )
			 ),
	ok.

-spec reg_player(list(), list()) -> ok.
%% @doc Send a register request
%%		 Use a string as name
reg_player(RegId, Password) ->
	Pass = crypto:hash(md5,Password),
    {ok, Len, Data} = tcp_protocol:client_pack(10000, [RegId, Pass]),
	send_msg ! {Len, Data},
	ok.

-spec login(string(),list()) -> ok.
%% @doc Send a login request
%%		Use a string as name
login(LogId, Password) ->
	Pass = crypto:hash(md5,Password),
	{ok, Len, Data} = tcp_protocol:client_pack(11000, [LogId, Pass]),
	send_msg ! {Len, Data},
	ok.

-spec enter_room(string()) -> ok.
%% @doc Send a enter room request
%%		Use the string room name as parameter
enter_room(RoomNum) ->
    {ok, Len, Data} = tcp_protocol:client_pack(12000, RoomNum),
	send_msg ! {Len, Data},
	ok.

-spec said(string()) -> ok.
%% @doc Send message to other client in the same room
said(Msg)->
	{ok, Len, Data} = tcp_protocol:client_pack(13000, Msg),
	send_msg ! {Len, Data},
	ok.

-spec leave_room() -> ok.
%% @doc Leave out a room
leave_room() ->
    {ok, Len, Data} = tcp_protocol:client_pack(14000, <<1>>),
	send_msg ! {Len, Data},
	ok.

-spec logout() -> ok.
%% @doc logout the chat room system
logout() ->
	{ok, Len, Data} = tcp_protocol:client_pack(15000, <<1>>),
	send_msg ! {Len, Data},
	ok.

-spec add_room(list())->ok.
%% @doc Admin to add a room.
add_room(RoomName) ->
	{ok, Len, Data} = tcp_protocol:client_pack(16000, RoomName),
	send_msg ! {Len, Data},
	ok.
-spec delete_room(list())->ok.
%% @doc delete a room
delete_room(RoomName) ->
	{ok, Len, Data} = tcp_protocol:client_pack(17000, RoomName),
	send_msg ! {Len, Data},
	ok.
-spec move(list(),list())->ok.
%% @doc move a user to a room
move(UserId, RoomName)->
	{ok, Len, Data} = tcp_protocol:client_pack(18000, [UserId, RoomName]),
	send_msg ! {Len, Data},
	ok.
-spec move_all(list(),list())->ok.
%% @doc move all the client in one room to another room.
move_all(Room1, Room2)->
	{ok, Len, Data} = tcp_protocol:client_pack(19000, [Room1, Room2]),
	send_msg ! {Len, Data},
	ok.
-spec silence(list())->ok.
%% @doc Set a user silent.
silence(UserId)->
	{ok, Len, Data} = tcp_protocol:client_pack(20000, UserId),
	send_msg ! {Len, Data},
	ok.
-spec unsilence(list())->ok.
%% @doc Set a user unsilent
unsilence(UserId)->
	{ok, Len, Data} = tcp_protocol:client_pack(21000, UserId),
	send_msg ! {Len, Data},
	ok.
-spec send_msg(atom()) -> ok.
%% @doc Send all the message use the Socket
send_msg(Socket)->
	receive
		{Len, Data} ->
			gen_tcp:send(Socket, <<Len:16>>),
			gen_tcp:send(Socket, Data)
	end,
	send_msg(Socket).

-spec recv_msg(atom(), list()) -> ok.

%%	 Receive all the message from the server
%%	10000:Result of register;
%%	11000:Result of login request;
%%	12000:Result of choose room request;
%%	13000:Rhe message for broadcasting;
%%	14000:Result of leave room request;
%%	15000:Re of disconnect message;
%%	16000:Add a room;
%%  0: Not a user
%%  1: Please login first
%%  2: Please enter room first
%%  3: Wrong password
%%  4: Id exist
%%	5: Logout message
recv_msg(Socket, RoomList) ->
	case gen_tcp:recv(Socket, 2) of
		{ok, <<Len:16>>} ->
			case gen_tcp:recv(Socket, Len) of
				{ok, <<?SC_REGISTER_REPLY:16, _Bin/binary>>} ->
					io:format("reg ok !~n"),
					recv_msg(Socket, RoomList); 
				{ok, <<?SC_LOGIN_REPLY:16, Bin/binary>>} ->
    		        UserId = binary_to_list(Bin),
    		        io:format("Welcom, ~s~nRoom list:~n", [UserId]),
					lists:foreach(fun(Name)->
										  io:format("~s~n",[Name])end
										  , RoomList),
					recv_msg(Socket, RoomList);
				{ok, <<?SC_CHOOSE_ROOM_REPLY:16, Len1:16, Bin/binary>>} ->
					<<Userid:Len1/binary-unit:8, _Len2:16, Roomnum/binary>> = Bin,
					UserId = binary_to_list(Userid),
					RoomNum = binary_to_list(Roomnum),
       		     	io:format("~s entered to ~s~n", [UserId, RoomNum]),
					recv_msg(Socket, RoomList);
   	 		    {ok, <<?SC_BROADCAST_MSG:16, Len1:16, Bin/binary>>} ->
					<<Userid:Len1/binary-unit:8, _Len2:16, Data/binary>> = Bin,
					UserId = binary_to_list(Userid),
					Msg = binary_to_list(Data),
      		        io:format("~s said: ~s~n", [UserId, Msg]),
            		recv_msg(Socket, RoomList);
				{ok, <<?SC_LEAVE_ROOM_REPLY:16, Len1:16, Bin/binary>>} ->
					<<Userid:Len1/binary-unit:8, _Len2:16, Roomnum/binary>> = Bin,
					UserId = binary_to_list(Userid),
					RoomNum = binary_to_list(Roomnum),
					io:format("~s leave ~s~n", [UserId, RoomNum]),
					recv_msg(Socket, RoomList);
				{ok, <<?SC_DISCONNECT:16, Len1:16, Bin/binary>>} ->
					<<Userid:Len1/binary-unit:8, _Len2:16, Roomnum/binary>> = Bin,
					UserId = binary_to_list(Userid),
					RoomNum = binary_to_list(Roomnum),
					io:format("~s disconnect ~s~n", [UserId, RoomNum]),
					recv_msg(Socket, []);
				{ok, <<?SC_NEW_ADDED_ROOM_NAME:16, Bin/binary>>} ->
    		        RoomName = binary_to_list(Bin),
					New_Rooms = [RoomName|RoomList],
					recv_msg(Socket, New_Rooms);
				{ok, <<?SC_NEW_DELETED_ROOM_NAME:16, Bin/binary>>} ->
    		        RoomName = binary_to_list(Bin),
					New_Rooms = lists:delete(RoomName, RoomList),
					recv_msg(Socket, New_Rooms);
				{ok, <<0>>}->
					io:format("Illegal name, please register first , 3Q !~n"),
					recv_msg(Socket, RoomList);
				{ok, <<1>>}->
					io:format("Please login first , 3Q !~n"),
					recv_msg(Socket, RoomList);
				{ok, <<2>>}->
					io:format("Please enter room first , 3Q !~n"),
					recv_msg(Socket, RoomList);
				{ok, <<3>>}->
					io:format("Wrong Password.~n"),
					recv_msg(Socket, RoomList);
				{ok, <<4>>}->
					io:format("Id exist.~n"),
					recv_msg(Socket, RoomList);
				{ok, <<5>>}->
					io:format("Logout success.~n"),
					recv_msg(Socket, []);
				{ok, <<6>>}->
					io:format("You have no privilege to do so.~n"),
					recv_msg(Socket, RoomList);
				{error, Reason} ->
					io:format("~p~n",[Reason]),
            		recv_msg(Socket, RoomList)
			end;
		{error, Reason} ->
			io:format("~p~n",[Reason])
	end.