using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO ;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

public delegate void OnDisconnectDelegate(Socket sock);
public delegate void MsgHandlerDelegate(MsgPacket mp);

public class ClientControl
{
    private static ClientControl _instance = null;

    public static ClientControl getInstance()
    {
        if (_instance == null)
            _instance = new ClientControl();
        return _instance;
    }

    public Socket sock = null;

    public int remote_port = 8000;

    public bool isConnect = false;

    public Queue<List<byte>> receiveQueue = new Queue<List<byte>>();
    public SocketReceiveTask socketReceiveTask = null;

    public Queue<List<byte>> sendQueue = new Queue<List<byte>>();
    public SocketSendBuff socketSendBuff = null;
    public bool iFDisconnect = false;//断线标志
    /// <summary>
    /// 处理注册回调消息协议   end*******************************
    /// </summary>

    public void OnDisconnect(Socket sock)
    {
        if (sock != this.sock)
        {
            Debug.Log("old socket");
            return;
        }
        if (this.isConnect)
        {
            Debug.Log("OnDisconnect:" + sock);
            iFDisconnect = true;
            close();
            this.isConnect = false;            
        //    _instance = null;
        }
    }

    /// <summary>
    /// 初始化sock连接
    /// </summary>
    public void init()
    {
       string IP_URL=NetWork.IP_URL;
       this.remote_port = NetWork.remote_port ;
        try
        {
            if (isConnect)
                close();

            Debug.Log("Start connect to"+IP_URL+":"/* + Config.server_host*/ + ",port:" + this.remote_port);
            //block sock
            this.sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint ipe = new IPEndPoint (IPAddress.Parse (this.remote_host), this.remote_port);

            Debug.Log("Start connect to" + IP_URL + ":"/* + Config.server_host */+ ",port:" + this.remote_port);
           
            this.sock.Connect(IP_URL, this.remote_port);

            this.isConnect = true;
            Debug.Log("connect sucess");

        }
        catch (Exception e)
        {
            this.isConnect = false;
            iFDisconnect = true;
           Debug.Log("connect fail exception:" + e.Message);
        }


        if (this.isConnect)
        {
            if (this.socketReceiveTask == null)
            {
                this.receiveQueue.Clear();
                this.socketReceiveTask = new SocketReceiveTask(this.sock, this.receiveQueue, this.OnDisconnect);
            }
            if (this.socketSendBuff == null)
            {
                this.sendQueue.Clear ();
                this.socketSendBuff = new SocketSendBuff(this.sock, this.sendQueue, this.OnDisconnect);
            }
        }
    }
    /// <summary>
    /// 关闭与断开网络
    /// </summary>
    public void close()
    {
        Debug.Log("ClientContrl:close");
        if (this.socketReceiveTask != null)
        {
            this.socketReceiveTask.close();
            this.socketReceiveTask = null;
        }
        if (this.socketSendBuff != null)
        {
            this.socketSendBuff.close();
            this.socketSendBuff = null;
        }

        if (this.isConnect)
        {
            Debug.Log("finit");
        //    this.sock.Shutdown(SocketShutdown.Both);
            this.sock.Disconnect(false);
            this.sock.Close  ();
            this.sock = null;
            this.isConnect = false;
        }
      //  _instance = null;
    }

   /// <summary>
   /// 
   /// </summary>
    public void finit()
    {

        iFDisconnect = true;
        close();
    }
    /// <summary>
    /// 发送数据
    /// </summary>
    /// <param name="buffer"></param>
    public void sendBuff(List<byte> buffer)
    {

        lock (this.sendQueue)
        {
            this.sendQueue.Enqueue(buffer);
        }
    }
    /// <summary>
    /// 接收到的数处理
    /// </summary>
    public void processReceiveQueue()
    {
        //every tick call this method
        lock (this.receiveQueue)
        {
            try
            {
                if (this.receiveQueue.Count > 0)
                {
                    foreach (List<byte> byteList in this.receiveQueue)
                    {

                        MsgPacket mp = new MsgPacket(byteList);

                        int protocol = mp.readShort();

                        if (ClientMsg.getInstance().msgMap.ContainsKey(protocol))
                        {

                            MsgHandlerDelegate handler = ClientMsg.getInstance().msgMap[protocol];
                            if (handler != null)
                                handler(mp);

                        }
                        else
                        {
                            Debug.Log("no mapping:" + protocol);
                        }

                    }

                    this.receiveQueue.Clear();

                } //if(this.receiveQueue.Count > 0){
            }
            catch (Exception e)
            {
                //    GameMain.exceptionLog = e.ToString() + "\n";
                Debug.Log("processReceiveQueue error:" + e.ToString());
            }
        } //lock(this.receiveQueue)
    }
    void IfNetWorkType()
    {
        
    }
}
