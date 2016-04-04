package com.unity.socket;


import java.net.ServerSocket;
import java.net.Socket;
import java.util.HashMap;


public class SocketServer {
    private HashMap<String,User> userMap;

    public  SocketServer(){
         userMap=new HashMap<String, User>();
    }

    public static void main(String[] args){
        new SocketServer().startServer();
    }

    public void startServer()
	{
		try
		{
			ServerSocket serverSocket = new ServerSocket(10000);
			System.out.println("服务器开启");
            while (true){
                Socket socket = serverSocket.accept();
                System.out.println("有用户登陆进来了");
                new UserThread(socket,userMap).start();
            }

        }catch (Exception e){
             System.out.println("服务器出现异常！" + e);
        }
    }
}
