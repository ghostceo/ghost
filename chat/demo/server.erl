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

%%jianglin
startd()->
	{ok,Listen} = gen_tcp:listen(2345,[binary,{packet,0},{reuseaddr,true},{active,true}]),
	spawn(fun()-> par_connectd(Listen) end).

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

par_connectd(Listen)->
	{ok,Socket} = gen_tcp:accept(Listen),
	io:format("~p~p~p~n",[?MODULE,?LINE,Socket]),
	spawn(fun()-> par_connectd(Listen) end),
	loopd(Socket).

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

loopd(Socket)->
	receive
		{tcp, Socket, Bin}->
			io:format("Server receiveed binary = ~p~n",[Bin]),
			routed(Bin,Socket),
			loopd(Socket);
		{msg,Bin,Socket} ->
			io:format("Server msg binary = ~p~n",[Bin]),
			gen_tcp:send(Socket,Bin),
			erlang:send_after(5000,self(),{msg,Bin,Socket}),
			loopd(Socket);
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

routed(<<SumLow:8,SumHigh:8,MethodL:8,MethodH:8,Bin/binary>>,Socket)->
	<<Sum:16>> = <<SumHigh:8,SumLow:8>>,
	<<Method:16>> = <<MethodH:8,MethodL:8>>,
	case Method of
		13601 ->
			ignore;
		13602->
			io:format("Get NpcId:~p,Reply:~p~n",[Sum,Method]),
			{Accname, Bin1} = read_string(Bin),
		    {PassW, Bin2}   = read_string(Bin1),
		    {Guid, Bin3}    = read_string(Bin2),
		    <<IsRe:8,_B/binary>>=Bin3,
    		io:format("Get NpcId:~p,Reply:~p~n",[Accname,{PassW,Guid,IsRe}]),
			% #m_activity_fecth_tos{npc_id=NpcID}=RTos,
			% RRoc = #m_level_gift_list_toc{cur_max_lv=22},
			% RBin0  =  packet(Method, RRoc),
			% Size = byte_size(RBin0),
			% RBin1  = <<Size:32>>,
			% RBin = list_to_binary([RBin1, RBin0]),
			Name = write_string(Accname),
			GuidR = write_string(Guid),
			Bin0 = <<Name/binary,GuidR/binary,1:32>>,
			BinR = pack(13602,Bin0),
			self() ! {msg,BinR,Socket};

			% Bin4 = <<100:32,Name/binary,0:32,0:8,0:32,0:32,0:32,0:32,0:32,0:32,0:32,0:32,0:32,0:32,0:32,0:32,0:32,0:32,0:32,0:32>>,
			% BinR2 = pack(13603,Bin4),
			% gen_tcp:send(Socket,BinR2);

			% io:format("Get NpcId:~p,Reply:~p~n",[NpcID,RBin]);
		_R->
			io:format("Get NpcId:~p,Reply:~p~n",[Sum,Method]),
			ignore
	end.
	
packet(_Method,Record) ->
    proto_pack:pack_toc(element(1, Record), Record).

unpack(<<MethodID:32, Bin/binary>>) -> 
    Tos = proto_unpack:unpack_tos(MethodID, Bin),
    io:format("Moudle:~p,Method:~p,Args:~p~n",[?ModuleID,MethodID,Tos]),
    {?ModuleID, MethodID, Tos}.


%% 读取字符串 返回的是string()
read_string(<<L:8,H:8,Bin/binary>>) ->
	<<L:16>> = <<H:8,L:8>>,
    case Bin of
        <<Str:L/binary-unit:8, Rest/binary>> ->
        	{binary_to_list(Str), Rest};
            % {unicode:characters_to_list(Str, utf8), Rest};
        _R1 ->
            {[],<<>>}
    end.

%%打包字符串
write_string(S) when is_list(S)->
    SB = iolist_to_binary(S),%unicode:characters_to_binary(S, utf8),
    Len = byte_size(SB),
    <<H:8,L:8>> = <<Len:16>>,
    <<L:8,H:8,SB/binary>>;

write_string(S) when is_binary(S)->
	Len = byte_size(S),
    <<H:8,L:8>> = <<Len:16>>,
    <<L:8,H:8, S/binary>>;

write_string(S) when is_integer(S)->
    SS = integer_to_list(S),
    SB = list_to_binary(SS),
    Len = byte_size(SB),
    <<H:8,L:8>> = <<Len:16>>,
    <<L:8,H:8, SB/binary>>;

write_string(_S) ->
    %util:errlog("pt:write_string error, Error = ~p~n", [S]),
    <<0:16, <<>>/binary>>.

 pack(Cmd,Data)->
 	<<CmdH:8,CmdL:8>> = <<Cmd:16>>,
 	L1 = byte_size(Data)+6,
 	L2 = byte_size(Data)+4,
 	<<LH:8,LL:8>> = <<L2:16>>,
 	<<L1:16, LL:8,LH:8, CmdL:8, CmdH:8, Data/binary>>.