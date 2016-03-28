#!/bin/bash
if [ "$#" -ne 2 ]; then
    echo "USAGE: $0 -f server_list_file cmd"
    exit -1
fi

file_name=$1
cmd_str=$2

cwd=$(pwd)
cd $cwd
serverlist_file="$cwd/$file_name"

if [ ! -e $serverlist_file ] ; then
    echo 'server.list not exist';
    exit 0
fi

while read line
do
    #echo $line
    if [ -n "$line" ] ; then
        echo "DOING--->>>>>" $line "<<<<<<<"
        ssh $line $cmd_str < /dev/null > /dev/null
        if [ $? -eq 0 ] ; then
            echo "$cmd_str done!"
        else
            echo "error: " $?
        fi
    fi
done < $serverlist_file
