-module(client).
-compile(export_all).

%%单次
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

%%erlang服务端使用
startb()->
	{ok,Socket} = gen_tcp:connect("192.168.253.100",2345,[binary,{packet,4}]),
	io:format("socket info =~p~n",[inet:peername(Socket)]),
	Sid = spawn(fun()->send_msgb(Socket) end),
	gen_tcp:controlling_process(Socket,Sid),
	put(aa,Sid),
	put(ss,Socket).

%%C++服务端使用
startc()->
	{ok,Socket} = gen_tcp:connect("localhost",2345,[binary,{packet,0}]),
	io:format("socket info =~p~n",[inet:peername(Socket)]),
	Sid = spawn(fun()->send_msgc(Socket) end),
	gen_tcp:controlling_process(Socket,Sid),
	put(aa,Sid),
	put(ss,Socket).

%%erlang
send_msgb(Socket)->
	receive 
		{tcp,Socket,Bin}->
			io:format("Client received binary =~p~n",[Bin]),
			Val = binary_to_term(Bin),
			io:format("Client result = ~p~n",[Val]),
			send_msgb(Socket);
		R ->
			io:format("Client received binary =~p,~p~n",[?LINE,R]),
			send_msgb(Socket)
	end.

%%C++
send_msgc(Socket)->
	receive 
		{tcp,Socket,Bin}->
			io:format("Client received binary =~p~n",[Bin]),
			Val = bitstring_to_term(Bin),
			io:format("Client result = ~p~n",[Val]),
			send_msgc(Socket);
		R ->
			io:format("Client received binary =~p,~p~n",[?LINE,R]),
			send_msgc(Socket)
	end.

%%erlang
senda(Str)->
	_Sid = get(ss),
	Socket = get(ss),
	Bin = term_to_binary(Str),
	io:format("Client send binary =~p~n",[Bin]),
	gen_tcp:send(Socket, Bin).

%%C++
sendb(Str)->
	_Sid = get(ss),
	Socket = get(ss),
	Bin = erlang:list_to_bitstring(io_lib:format("~w", [Str])),
	gen_tcp:send(Socket, Bin).

bitstring_to_term(undefined) -> undefined;
bitstring_to_term(BitString) ->
    string_to_term(binary_to_list(BitString)).

string_to_term(String) ->
    case erl_scan:string(String++".") of
        {ok, Tokens, _} ->
            case erl_parse:parse_term(Tokens) of
                {ok, Term} ->Term;
                _Err -> undefined
            end;
        _Error -> undefined
    end.

all_to_binary(List) -> all_to_binary(List, []).

all_to_binary([], Result) -> list_to_binary(Result);
all_to_binary([P | T], Result) when is_list(P) -> all_to_binary(T, lists:append(Result, P));
all_to_binary([P | T], Result) when is_integer(P) -> all_to_binary(T, lists:append(Result, integer_to_list(P)));
all_to_binary([P | T], Result) when is_binary(P) -> all_to_binary(T, lists:append(Result, binary_to_list(P)));
all_to_binary([P | T], Result) when is_float(P) -> all_to_binary(T, lists:append(Result, float_to_list(P)));
all_to_binary([P | T], Result) when is_atom(P) -> all_to_binary(T, lists:append(Result, atom_to_list(P))).
