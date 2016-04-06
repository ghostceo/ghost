using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public delegate int ReceiveMessage(ByteArray byteArray);
public delegate void SendQueueMessage();
//public delegate void SendMessage()
public delegate void MessageHandler(IncommingBase message);
public class GameNetManager
{
    private GameNet mSocket;
    private static GameNetManager instance;
    private ReceiveMessage receiveMessage;
    private SendQueueMessage sendQueueMessage;
    private bool isConnected;
    private List<ByteArray> waitSendQueue;
    private Dictionary<int , List<IMessageHandler>> msgHandlerDic = new Dictionary<int , List<IMessageHandler>>();
    private List<IncommingBase> receivedMessageList = new List<IncommingBase>();
    private Action<bool> onConnectFun;
    private GameNetManager():base()
    {
        mSocket = new GameNet();
        waitSendQueue = new List<ByteArray>();
        receiveMessage = new ReceiveMessage(OnReceiveMessage);
        sendQueueMessage = new SendQueueMessage(SendQueue);
    }
    public static GameNetManager ins
    {
        get
        {
            if (instance == null)
            {
                instance = new GameNetManager();
            }
            return instance;
        }
    }
    public void Init(string ip , int port = 443 , Action<bool> _connectedCall = null)
    {
        if(mSocket == null)
            return;
        onConnectFun = _connectedCall;
        mSocket.connectedCall = ConnectedCall;
        mSocket.BeginConnect(ip, port, receiveMessage , sendQueueMessage);
        if (!isConnected)
            return;
    }

    private void ConnectedCall(bool connected)
    {
        isConnected = connected;
        if(onConnectFun != null)
            onConnectFun(connected);
        Debug.Log("是否连上了: " + isConnected);
    }
    public void SendMessage(OutgoingBase message)
    {
        if (isConnected)
        {
            ByteArray byteArray = new ByteArray();
            message.fill2s(byteArray);
            mSocket.Send(byteArray);
        }
    }
    //public void SendMessage(m_test_simple_tos mtst)
    //{
    //    if (isConnected)
    //    {
    //        ByteArray byteArray = new ByteArray();
    //        mtst.fill(byteArray);
    //        waitSendQueue.Add(byteArray);
    //        SendQueue();
    //        //mSocket.Send(byteArray);
    //    }
    //}
    //public void SendMessage(m_test_complicate_tos mtct)
    //{
    //    if (isConnected)
    //    {
    //        ByteArray byteArray = new ByteArray();
    //        mtct.fill(byteArray);
    //        waitSendQueue.Add(byteArray);
    //        SendQueue();
    //        //mSocket.Send(byteArray);
    //    }
    //}
    public void SendQueue()
    {
        if (mSocket != null && !mSocket.isSending && waitSendQueue.Count > 0)
        {
            ByteArray ba = waitSendQueue[0];
            mSocket.Send(ba);
            waitSendQueue.RemoveAt(0);
        }
    }
    public void Update()
    {
        lock (this.receivedMessageList)
        {
            for (int i = 0 ; i < this.receivedMessageList.Count ; i++)
            {
                IncommingBase message = receivedMessageList[i];
                HandleMessage(message);
            }
            this.receivedMessageList.Clear();
        }
    }
    public void HandleMessage(IncommingBase message)
    {
        int protocolID = message.protocol;
        if (msgHandlerDic.ContainsKey(protocolID))
        {
            Debug.Log("正在处理" + protocolID + "协议");
            for (int i = 0; i < msgHandlerDic[protocolID].Count; i++)
            {
                //我在考虑要不要加个try-catch@ling
                msgHandlerDic[protocolID][i].HandleMessage(message);
            }
        }
        else
        {
            Debug.Log("没有 " + protocolID + "的处理监听");
        }
    }
    //返回0代表正常,1代表协议不齐全,2代表出错等等
    public int OnReceiveMessage(ByteArray byteArray)
    {
        ByteArray ba = new ByteArray();
        while (byteArray.Length - byteArray.Postion >= 6)
        {
            int protoLength = byteArray.ReadInt();
            int protocolID = byteArray.ReadInt();//.ReadShort();
            IncommingBase message = Commands.getInstance().GetHandler(protocolID);
            if (message != null)
            {
                message.protocol = (short)protocolID;
                message.fill2c(byteArray);
                receivedMessageList.Add(message);
            }
            else
            {
                byteArray.Postion += protoLength;
                Debug.Log("can not find ID is " + protocolID + "'s message handler class");
            }
        }
        //int returnFlag = 0;
        //while(byteArray.Length - byteArray.Postion >= 6)
        //{
        //    int protoLength = byteArray.ReadInt();
        //    int protocolID = byteArray.ReadInt();//.ReadShort();
        //    IncommingBase message = Commands.getInstance().GetHandler(protocolID);
        //    if (message != null)
        //    {
        //        message.protocol = (short)protocolID;
        //        message.fill2c(byteArray);
        //        if (msgHandlerDic.ContainsKey(protocolID))
        //        {
        //            for (int i = 0; i < msgHandlerDic[protocolID].Count; i++)
        //            {
        //                //我在考虑要不要加个try-catch@ling
        //                msgHandlerDic[protocolID][i].handleMessage(message);
        //            }
        //        }
        //        else
        //        {
        //            Debug.Log("没有 " + protocolID + "的处理监听");
        //        }
        //    }
        //    else
        //    {
        //        byteArray.Postion += protoLength;
        //        Debug.Log("can not find " + protocolID + "message handler class");
        //    }
            
        //    //if (protocolID == 401)
        //    //{
        //    //    m_test_simple_toc mtst = new m_test_simple_toc();
        //    //    mtst.fill(byteArray);
        //    //    Debug.Log(mtst.role_name);
        //    //    Debug.Log("收到401协议");
        //    //    returnFlag = 0;
        //    //    break;
        //    //}
        //    //else if(protocolID == 402)
        //    //{
        //    //    m_test_complicate_toc mtct = new m_test_complicate_toc();
        //    //    mtct.fill(byteArray);
        //    //    Debug.Log(mtct.name);
        //    //    Debug.Log("收到402协议");
        //    //    returnFlag = 0;
        //    //    break;
        //    //}
        //}
        return 0;
    }
    private OutgoingBase ParseByteToMessage(ByteArray byteArray)
    {
        int protocolID = byteArray.ReadInt();
        return new OutgoingBase();
    }
    //已经可以正常使用
    //public int OnReceiveMessage(ByteArray byteArray)
    //{
    //    m_test_simple_toc mtsc = ParseByteTo(byteArray);
    //    Debug.Log(mtsc.role_name);
    //    return 0;
    //}
    //private OutgoingBase ParseByteToMessage(ByteArray byteArray)
    //{
    //    int protocolID = byteArray.ReadInt();
    //    return new OutgoingBase();
    //}
    //private m_test_simple_toc ParseByteTo(ByteArray byteArray)
    //{
    //    //int protocolID = byteArray.ReadInt();
    //    m_test_simple_toc mtsc = new m_test_simple_toc();
    //    mtsc.fill(byteArray);
    //    return mtsc;
    //}
    public void AddMessageHandler(int messageID , IMessageHandler handler)
    {
        if(!msgHandlerDic.ContainsKey(messageID))
        {
             msgHandlerDic[messageID] = new List<IMessageHandler>();
        }
        msgHandlerDic[messageID].Add(handler);
    }
    public void AddFunctionHandler(int messageID, MessageHandler handler)
    {
        if (!msgHandlerDic.ContainsKey(messageID))
        {
            msgHandlerDic[messageID] = new List<IMessageHandler>();
        }
        //msgHandlerDic[messageID].Add(handler);
    }
    public void RemoveCommandHandler(int messageID , IMessageHandler handler)
    {
        if (msgHandlerDic.ContainsKey(messageID))
        {
            List<IMessageHandler> handlers = msgHandlerDic[messageID];
            int index = handlers.IndexOf(handler);
            if (index != -1)
            {
                handlers.RemoveAt(index);
            }
        }
    }

    public bool IsConnected
    {
        get
        {
            return isConnected;
        }
    }
}
