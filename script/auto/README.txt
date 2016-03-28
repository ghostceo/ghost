将需要操作的云主机的ip，ssh的端口，账号，旧密码和新密码写到hosts.txt文件中，每一行代表一个主机

比如

10.0.0.1 22 root old_passwd new_passwd

然后执行 

./batch.py


执行auto.sh
比如：./auto.sh auto.txt 'rm -rf /root/data/*.txt'