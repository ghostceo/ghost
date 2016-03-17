-module(server).
-compile(export_all).

%%only one
starta()->
	{ok,Listen} = gen_tcp:listen(2345,[binary,{packet,4},{reuseaddr,true},{active,true}]),
	{ok,Socket} = gen_tcp:accept(Listen),
	gen_tcp:close(Listen),
	loop(Socket).

%%顺序
startb()->
	{ok,Listen} = gen_tcp:listen(2345,[binary,{packet,4},{reuseaddr,true},{active,true}]),
	seq_loop(Listen).

seq_loop(Listen)->	
	{ok,Socket} = gen_tcp:accept(Listen),
	io:format("listten info =~p,~p,~p~n",[?LINE,Listen,inet:peername(Listen)]),
	io:format("socket info =~p,~p,~p~n",[?LINE,Socket,inet:peername(Socket)]),
	loop(Socket),
	seq_loop(Listen).

%%并行
startc()->
	{ok,Listen} = gen_tcp:listen(2345,[binary,{packet,4},{reuseaddr,true},{active,true}]),
	spawn(fun()-> par_connect(Listen) end).

par_connect(Listen)->
	{ok,Socket} = gen_tcp:accept(Listen),
	spawn(fun()-> par_connect(Listen) end),
	loop(Socket).

loop(Socket)->
	receive
		{tcp, Socket, Bin}->
			io:format("Server receiveed binary = ~p~n",[Bin]),
			Str = binary_to_term(Bin),
			io:format("Server(unpacked) ~p~n",[Str]),
			Reply = "hello from server",
			io:format("Server replying = ~p~n",[Reply]),
			gen_tcp:send(Socket,term_to_binary(Reply)),
			loop(Socket);
		{tcp_close, Socket}->
			io:format("Server socket cloased~n")
	end.