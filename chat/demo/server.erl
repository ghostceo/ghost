-module(server).
-include("all_pb.hrl").
-include("mm_define.hrl").

-compile(export_all).

-define(ModuleID,(MethodID div 100)).

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
	{ok,Listen} = gen_tcp:listen(2345,[binary,{packet,0},{reuseaddr,true},{active,true}]),
	spawn(fun()-> par_connect(Listen) end).

%%unity
startu()->
	{ok,Listen} = gen_tcp:listen(2345,[binary,{packet,0},{reuseaddr,true},{active,true}]),
	spawn(fun()-> par_connectu(Listen) end).

par_connect(Listen)->
	{ok,Socket} = gen_tcp:accept(Listen),
	io:format("somebody come ~p,~p,~p~n",[?MODULE,?LINE,Socket]),
	spawn(fun()-> par_connect(Listen) end),
	loop(Socket).

par_connectu(Listen)->
	{ok,Socket} = gen_tcp:accept(Listen),
	io:format("~p~p~p~n",[?MODULE,?LINE,Socket]),
	spawn(fun()-> par_connectu(Listen) end),
	loopu(Socket).

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


loopu(Socket)->
	receive
		{tcp, Socket, Bin}->
			io:format("Server receiveed binary = ~p~n",[Bin]),
			route(Bin,Socket),
			loopu(Socket);
		{tcp_close, Socket}->
			io:format("Server socket cloased~n")
	end.

route(<<_Unique:32,Bin/binary>>,Socket)->
	case unpack(Bin) of
		{?ACTIVITY, Method, RTos} ->
			#m_activity_fecth_tos{npc_id=NpcID}=RTos,
			RRoc = #m_level_gift_list_toc{cur_max_lv=22},
			RBin0  =  packet(Method, RRoc),
			Size = byte_size(RBin0),
			RBin1  = <<Size:32>>,
			RBin = list_to_binary([RBin1, RBin0]),
			gen_tcp:send(Socket,RBin),
			io:format("Get NpcId:~p,Reply:~p~n",[NpcID,RBin]);
		_->
			ignore
	end.
	
packet(_Method,Record) ->
    proto_pack:pack_toc(element(1, Record), Record).

unpack(<<MethodID:32, Bin/binary>>) -> 
    Tos = proto_unpack:unpack_tos(MethodID, Bin),
    io:format("Moudle:~p,Method:~p,Args:~p~n",[?ModuleID,MethodID,Tos]),
    {?ModuleID, MethodID, Tos}.