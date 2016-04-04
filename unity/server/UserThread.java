package com.unity.socket;

import java.io.*;
import java.net.Socket;
import java.util.Iterator;

import java.io.ByteArrayOutputStream;

import java.io.DataOutputStream;
import java.util.HashMap;


public class UserThread extends Thread{
    /** 错误消息命令 **/
	public static final int 			ERROR = 0;
	/** 登陆消息命令 **/
	public static final int 			LOGIN = 1001;
    private Socket socket;
    private HashMap<String,User> userMap;
    private User user;
    private ByteArrayOutputStream byteOutput;
    private DataOutputStream output;
    private DataInputStream input;

    public UserThread(Socket socket,HashMap<String,User> userMap){
        this.socket=socket;
        this.userMap=userMap;
    }

    //重新初始化2个新的output
	private void initOutput()
	{
		byteOutput = new ByteArrayOutputStream();
		output = new DataOutputStream(byteOutput);
	}

    public void sendAllUser(byte[] bytes) throws Exception
	{
		for(Iterator<User> it = userMap.values().iterator(); it.hasNext();)
		{
			sendMessage(it.next().getSocket(),bytes);
		}
	}

    public void sendMessage(Socket socket,byte[] bytes) throws Exception
	{
		DataOutputStream dataOutput = new DataOutputStream(socket.getOutputStream());
		dataOutput.write(bytes);
		dataOutput.flush();
	}

    public short readShort()throws IOException{
          byte[] buf=new byte[2];
          input.read(buf);
          return ConvertType.getShort(buf,true);
    }

    public int readInt()throws IOException{
          byte[] buf=new byte[4];
          input.read(buf);
          return ConvertType.getInt(buf, true);
    }

    public long readLong()throws IOException{
          byte[] buf=new byte[8];
          input.read(buf);
          return ConvertType.getLong(buf, true);
    }

   public float readFloat()throws IOException{
          byte[] buf=new byte[4];
          input.read(buf);
          return ConvertType.getFloat(buf, true);
    }

    public String readString()throws IOException{
          int length=readInt();
          byte[] buf=new byte[length];
          input.read(buf);
          return new String(buf);
    }



    public void run(){
        try{
            input = new DataInputStream(socket.getInputStream()) ;
            while (true){
                int cmd=0;
                cmd=readInt();
                System.out.println("命令号:"+cmd);
                if(cmd==ERROR){   //收空包
                    userMap.remove(user.getName());
                    Message msg=new Message();
                    msg.writeString(user.getName()+" 离开");
                    System.out.println(user.getName()+" 离开");
                    try{
                         sendAllUser(msg.getBuff().array());
                    }catch (Exception ex){
                         System.out.println("sendAllUserErr: "+ex.toString());
                     }
                    break;
                }
                switch (cmd){
                    case LOGIN:
                        System.out.println("读取用户名");
                        String userName = readString();
                        user = new User();
                        user.setName(userName);
                        user.setSocket(socket);
                        System.out.println(userName);
                        if(userMap.containsKey(userName)) {
                            Message msg=new Message();
                            msg.writeString("昵称重复");
							sendMessage(socket,msg.getBuff().array());
                            msg.clear();
                            msg=null;
                        }else{
                            System.out.println("有新用户进入:" + userName);
							userMap.put(userName, user);
							initOutput();
                            Message msg=new Message();
                            msg.writeString("连接成功");
							sendMessage(socket,msg.getBuff().array());
                            msg.clear();
                            msg=null;
                        }
                        break;
                }
            }
        }catch (Exception e){
             e.printStackTrace();
             userMap.remove(user.getName());
             Message msg=new Message();
             msg.writeString(user.getName()+" 离开");
            System.out.println(user.getName()+" 离开");
            try{
                sendAllUser(msg.getBuff().array());
            }catch (Exception ex){
                System.out.println("sendAllUserErr: "+ex.toString());
            }

        }
    }
}
