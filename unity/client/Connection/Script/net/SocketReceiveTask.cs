
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Collections;
using System.Net;
using System.Net.Sockets;

public class SocketReceiveTask
{
    public Thread thread = null;
    public Socket sock = null;
    public Queue<List<byte>> queue;
    public int maxRecvSize = 10485760; //10m byte
    public bool isReadingHead = true;
    public int needReadBuffLen = 0;
    public bool running = true;
    public OnDisconnectDelegate onDisconnect = null;

    public SocketReceiveTask(Socket sock, Queue<List<byte>> queue, OnDisconnectDelegate onDisconnect = null)
    {

        this.sock = sock;
        this.queue = queue;
        this.onDisconnect = onDisconnect;
        this.running = true;
        this.isReadingHead = true;
        this.thread = new Thread(new ThreadStart(this.run));
        this.thread.IsBackground = true; //back group.for main thread dead,i dead.
        this.thread.Start();
    }
    /// <summary>
    /// 
    /// </summary>
    public void close()
    {
        if (this.running)
        {
            this.running = false;
            this.isReadingHead = false;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void run()
    {
        while (this.running)
        {
            if (this.isReadingHead)
            {
                this.needReadBuffLen = 4;
                byte[] bytes = new byte[this.needReadBuffLen];
                try
                {
                    //block read
                    int readCount = this.sock.Receive(bytes, this.needReadBuffLen, 0);
                    //for (int i = 0; i < readCount; i++)
                    //{
                    //    GameMain.Debug("包头数据长度＝" + i + "data=" + bytes[i]);
                    //}
                    if (readCount == 0)
                    {
                        //read error disconnect it
                        //Debug.LogError("Socket Close By Remote");
                        if (this.onDisconnect != null)
                        {
                            Debug.Log("Receive onDisconnect1");
                            this.onDisconnect(this.sock);
                        }
                        this.running = false;
                        break;
                    }
                    else
                    {
                        this.needReadBuffLen = MsgPacketUtil.readInt(bytes);
                        
                        if (this.needReadBuffLen > this.maxRecvSize)
                        {
                            //over maxRecvSize disconnect it
                            if (this.onDisconnect != null)
                            {
                                Debug.Log("Receive onDisconnect2");
                                this.onDisconnect(this.sock);
                            }
                            this.running = false;
                            break;
                        }
                        this.isReadingHead = false;
                    }
                }
                catch (Exception e)
                {
                    //read exception disconnect it
                    Debug.LogError("Receive:" + e.ToString());
                    if (this.onDisconnect != null)
                    {
                        Debug.Log("Receive onDisconnect3");
                        this.onDisconnect(this.sock);
                    }
                    this.running = false;
                    break;
                }
            }
            else
            { //if (this.isReadingHead){
                byte[] temp = new byte[this.needReadBuffLen];
                byte[] buf = new byte[this.needReadBuffLen];
                int read_offset = 0;
                try
                {
                    //block read
                    while (true)
                    {
                        if (!this.running)
                            break;
                        int readCount = this.sock.Receive(temp, this.needReadBuffLen, 0);
                        this.needReadBuffLen -= readCount;
                        //for (int i = 0; i < readCount; i++)
                        //{
                        //    GameMain.Debug("包数据长度＝"+i+"data="+temp[i].ToString() );
                        //}
                        if (readCount == 0)
                        {
                            //read error disconnect it
                            if (this.onDisconnect != null)
                            {
                                Debug.Log("Receive onDisconnect4");
                                this.onDisconnect(this.sock);
                            }
                            this.running = false;
                            break;
                        }
                        else
                        {
                            for (int i = 0; i < readCount; i++)
                            {
                                buf[read_offset + i] = temp[i];
                            }
                            read_offset += readCount;
                            //cause of block read,so read complete
                            if (needReadBuffLen == 0)
                            {
                                List<byte> bytes = new List<byte>();
                                
                                bytes.AddRange(buf);
                                int data=( (((short )buf[0] & 0x00ff) << 8) | ((short )buf[1]&0x00ff));
                                //if (data != 9911)
                                //{
                                //      string st = "协议号：" + data.ToString();
                                Debug.Log(data);
                                //    GameDelegate.ActivateEvent_DebugInfo(data);
                                //}                                
                                lock (this.queue)
                                {
                                    this.queue.Enqueue(bytes);
                                }
                                this.isReadingHead = true;
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("Receive:" + e.ToString());
                    //read exception disconnect it
                    if (this.onDisconnect != null)
                    {
                        Debug.Log("Receive onDisconnect5");
                        this.onDisconnect(this.sock);
                    }
                    this.running = false;
                    break;
                }
            }  //if (this.isReadingHead){
            //cause of block socket so no sleep.the socket will wait sleep read.
            //Thread.Sleep(10);
        } //while(this.running){
        if (!this.running)
        {
            this.thread.Abort();
        }
    }
    
}
