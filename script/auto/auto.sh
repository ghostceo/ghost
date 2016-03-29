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

#for ip in `awk '{print $1}' $serverlist_file` 这个过滤不了#
for ip in `cat $serverlist_file | grep -v ^# | awk '{print $1}'`
do
    port=`awk -v I="$ip" '{if(I==$1)print $2}' $serverlist_file`
    user=`awk -v I="$ip" '{if(I==$1)print $3}' $serverlist_file`
    pass=`awk -v I="$ip" '{if(I==$1)print $4}' $serverlist_file`
    
    #num1
    echo "DOING--->>>>>" $ip "<<<<<<<"
    expect /root/data/auto/auto.exp $ip $port $user $pass
    
    # #num2
    # echo "DOING--->>>>>" $ip "<<<<<<<"
    # ssh $ip $cmd_str < /dev/null > /dev/null
    # if [ $? -eq 0 ] ; then
    #     echo "$cmd_str done!"
    # else
    #     echo "error: " $?
    # fi
    # #

done

# num3
# while read line
# do
#     #echo $line
#     if [ -n "$line" ] ; then
#         echo "DOING--->>>>>" $line "<<<<<<<"
#         ssh $line $cmd_str < /dev/null > /dev/null
#         if [ $? -eq 0 ] ; then
#             echo "$cmd_str done!"
#         else
#             echo "error: " $?
#         fi
#     fi
# done < $serverlist_file
