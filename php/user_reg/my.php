<?php
session_start();

//����Ƿ��¼����û��¼��ת���¼����
if(!isset($_SESSION['userid'])){
	header("Location:login.html");
	exit();
}

//�������ݿ������ļ�
include('conn.php');
$userid = $_SESSION['userid'];
$username = $_SESSION['username'];
$user_query = mysql_query("select * from user where uid=$userid limit 1");
$row = mysql_fetch_array($user_query);
echo '�û���Ϣ��<br />';
echo '�û�ID��',$userid,'<br />';
echo '�û�����',$username,'<br />';
echo '���䣺',$row['email'],'<br />';
echo 'ע�����ڣ�',date("Y-m-d", $row['regdate']),'<br />';
echo '<a href="login.php?action=logout">ע��</a> ��¼<br />';
?>