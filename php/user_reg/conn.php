<?php
/*****************************
*���ݿ�����
*****************************/
$conn = @mysql_connect("localhost","root","root123");
if (!$conn){
	die("�������ݿ�ʧ�ܣ�" . mysql_error());
}
mysql_select_db("test", $conn);
//�ַ�ת��������
mysql_query("set character set 'gbk'");
//д��
mysql_query("set names 'gbk'");
?>