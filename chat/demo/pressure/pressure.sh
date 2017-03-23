ERL=erl
ERLC=erlc

function do_make()
{
	mkdir -p ebin
	/bin/cp -rf src/pressure.app ebin
	for file in src/*.erl; do
		${ERLC} -o ebin ${file}
	done
}

function do_start()
{

	${ERL} -pa ebin -s pressure
}

function usage()
{
    echo "usage: ${script} <command> [options]"
    echo "valid commands:"
	echo "    make    编译"
	echo "    start   启动"
}

case "$1" in
	make)
		do_make
		;;
	start)
		do_start
		;;
	*)
		usage
		;;
esac