-module(client).
-compile(export_all).

starta(Str)->
	{ok,Socket} = gen_tcp:connect("localhost",2345,[binary,{packet,4}]),
	ok = gen_tcp:send(Socket, term_to_binary(Str)),
	receive 
		{tcp,Socket,Bin}->
			io:format("Client received binary =~p~n",[Bin]),
			Val = binary_to_term(Bin),
			io:format("Client result = ~p~n",[Val]),
			gen_tcp:close(Socket)
	end.

startb()->
	{ok,Socket} = gen_tcp:connect("localhost",2345,[binary,{packet,4}]),
	io:format("socket info =~p~n",[inet:peername(Socket)]),
	Sid = spawn(fun()->send_msg(Socket) end),
	gen_tcp:controlling_process(Socket,Sid),
	put(aa,Sid),
	put(ss,Socket).

send_msg(Socket)->
	receive 
		{tcp,Socket,Bin}->
			io:format("Client received binary =~p~n",[Bin]),
			Val = binary_to_term(Bin),
			io:format("Client result = ~p~n",[Val]),
			send_msg(Socket);
		R ->
			io:format("Client received binary =~p,~p~n",[?LINE,R]),
			send_msg(Socket)
	end.

send(Str)->
	_Sid = get(ss),
	Socket = get(ss),
	gen_tcp:send(Socket, term_to_binary(Str)).