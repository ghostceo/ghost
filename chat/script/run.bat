set COOKIE=xyyo
set NODE_NAME=chat_room@127.0.0.1
set CONFIG_FILE=run

set SMP=auto
set ERL_PROCESSES=102400

werl +P %ERL_PROCESSES% -smp %SMP% -pa ../ebin -name %NODE_NAME% -setcookie %COOKIE% -boot start_sasl -config %CONFIG_FILE% -s main server_start