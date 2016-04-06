using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System;
using System.Collections.Generic;

public class GameNet
{
    //socket
    private Socket mSocket;
    //接收线程,因为socket是异步的,所以暂时不用,有需要再用上
    private ReceiverThread rt;
    //发送线程,因为socket是异步的,所以暂时不用,有需要再用上
    private SenderThread st;
    //接收二进制缓存
    public Byte[] receiveBuff = new Byte[4096];
    //接收缓存的位置
    public int receivePosition = 0;
    //接收到的消息的队列,可能我这边不用
    private Queue<ByteArray> mRecvQueue = new Queue<ByteArray>();
    private ushort id = 0;

    public Action<bool> connectedCall;
    private ReceiveMessage _receiveFun;
    private SendQueueMessage _sendFun;

    public bool isSending = false;

    public GameNet()
    {

    }

    // 同步连接服务器
    public bool Connect(string ip, int port , ReceiveMessage receiveFun)
    {
        if (this.mSocket != null) 
        {
            DisConnect();
        }
        mSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        if (mSocket == null)
        {
            return false;
        }
        _receiveFun = receiveFun;
        try
        {
            mSocket.Connect(ip, port);
        }
        catch (Exception exception)
        {
            Debug.Log(exception.Message+"错误异常：" + exception.StackTrace);
            return false;
        }
        receivePosition = 0;
        if (!RecvMessageFromSocket()) 
        {
            DisConnect();
            return false;
        }
        return true;
    }

    // 异步连接服务器
    public void BeginConnect(string ip, int port, ReceiveMessage receiveFun , SendQueueMessage sendFun)
    {
        if (this.mSocket != null)
        {
            DisConnect();
        }
        mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        if (mSocket == null)
        {
            connectedCall(false);
            return;
        }
        _receiveFun = receiveFun;
        _sendFun = sendFun;
        try
        {
            mSocket.BeginConnect(ip, port, new AsyncCallback(ConnectCallBack), this);
        }
        catch (Exception exception)
        {
            Debug.Log(exception.Message + "错误异常：" + exception.StackTrace);
            connectedCall(false);
            return;
        }
    }

    private void ConnectCallBack(IAsyncResult ar)
    {
        try
        {
            mSocket.EndConnect(ar);
            receivePosition = 0;
            if (!RecvMessageFromSocket())
            {
                DisConnect();
                connectedCall(false);
            }
            connectedCall(true);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message + "连接服务回调异常：" + ex.StackTrace);
            connectedCall(false); 
        }
    }

    public void DisConnect()
    {
        if (IsConnected())
        {
            try
            {
                mSocket.Disconnect(true);
            }
            catch (Exception exception)
            {
                Debug.Log("断开网络连接发生错误：" + exception.StackTrace);
            }
            mSocket = null;
            receivePosition = 0;
        }
    }

    public bool IsConnected()
    {
        if (mSocket == null)
        {
            return false;
        }
        return mSocket.Connected;
    }

    private bool RecvMessageFromSocket()
    {
        if (mSocket != null)
        {
            try
            {
                SocketError socketError;
                mSocket.BeginReceive(
                    receiveBuff, 
                    receivePosition, 
                    this.receiveBuff.Length - this.receivePosition, 
                    SocketFlags.None, 
                    out socketError,
                    new AsyncCallback(RecvCallBack), this);
            }
            catch (Exception exception)
            {
                Debug.Log("接受Socket数据发生错误：" + exception.StackTrace);
                return false;
            }
            return true;
        }
        return false;
    }
    private Byte[] lastUnreadByte = new Byte[65535];
    private ByteArray buffByteArray = new ByteArray(8096);
    private int lastUnreadLength;
    private void RecvCallBack(IAsyncResult ar)
    {
        int num = 0;
        try
        {
            /*
                * EndReceive 方法将一直阻止到有数据可用为止。 如果您使用的是无连接协议，
                * 则 EndReceive 将读取传入网络缓冲区中第一个排队的可用数据报。 
                * 如果您使用的是面向连接的协议，则 EndReceive 方法将读取所有可用的数据，
                * 直到达到 BeginReceive 方法的 size 参数所指定的字节数为止。 
                * 如果远程主机使用 Shutdown 方法关闭了 Socket 连接，并且所有可用数据均已收到，
                * 则 EndReceive 方法将立即完成并返回零字节。
                */
            SocketError socketError;
            num = this.mSocket.EndReceive(ar, out socketError);
        }
        catch (Exception exception)
        {
            if (IsConnected())
            {
                Debug.Log(exception.Message + "接受Socket数据回调时发生错误：" + exception.StackTrace);
            }
            return;
        }
        if (num == 0)
        {
            Debug.Log("接受Socket数据num=0：DisConnect()");
            this.DisConnect();
        }
        else
        {
            buffByteArray.CreateFromSocketBuffWithProtocolLength(this.receiveBuff, num);
            if (_receiveFun(buffByteArray) > 1)
            {
                Debug.Log("解析socket数据出错：DisConnect()");
                DisConnect();
            }
            //清除掉已经读了的协议
            buffByteArray.RemoveReaded();
            //继续异步接收
            this.RecvMessageFromSocket();




            //this.receivePosition += num;
            //while (true)
            //{
            //    if (!this.IsConnected())
            //    {
            //        break;
            //    }
            //    ByteArray byteArray = new ByteArray();
            //    if (!this.ParseMessage(ref this.receiveBuff, ref this.receivePosition, ref byteArray))
            //    {
            //        break;
            //    }
            //    //this.mRecvQueue.Enqueue(byteArray);
            //    //立即处理
            //    _receiveFun(byteArray);
            //}
            //this.RecvMessageFromSocket();
        }
    }

    private bool ParseMessage(ref byte[] buff, ref int len, ref ByteArray byteArray)
    {
        //内容长度2个字节，id 2个字节 ，moduleId 1个字节 methodId 1个字节 checksum 2个字节 = 8,如果当前BUFF总长度不够8个字节，就等待下次再读取
        //if (len < 8)
        //{
        //    return false;
        //}
        int size = LittleEndianBitConverter.Big.ToInt32(buff, 0);//一条消息协议数据包的长度
        if (size < 3 || size > 2048)
        {
            this.DisConnect();
            Debug.Log("数据包大小过长或者较短导致断开连接size=" + size);
            return false;
        }
        if (len < size) //出现粘包情况了，也就是还有一部分数据没有读取到，需要等下次一起读取
        {
            return false;
        }
        if (!byteArray.CreateFromSocketBuff(buff, size))
        {
            RemoveRecvBuff(ref buff, ref len, size + 4);
            return false;
        }
        RemoveRecvBuff(ref buff, ref len, size + 4);
        return true;

    }

    private void RemoveRecvBuff(ref byte[] buff, ref int nLen, int nSize)
    {
        if (nSize <= nLen)
        {
            byte[] destinationArray = new byte[4096];
            Array.Copy(buff, nSize, destinationArray, 0, nLen - nSize);//nLen - nSize
            //buff = destinationArray;
            Array.Copy(destinationArray, 0, buff, 0, nLen - nSize);//nLen - nSize
            nLen -= nSize;
        }
    }
    //以下是已经可用版本
    //private void RecvCallBack(IAsyncResult ar)
    //{
    //    int num = 0;
    //    try
    //    {
    //        /*
    //            * EndReceive 方法将一直阻止到有数据可用为止。 如果您使用的是无连接协议，
    //            * 则 EndReceive 将读取传入网络缓冲区中第一个排队的可用数据报。 
    //            * 如果您使用的是面向连接的协议，则 EndReceive 方法将读取所有可用的数据，
    //            * 直到达到 BeginReceive 方法的 size 参数所指定的字节数为止。 
    //            * 如果远程主机使用 Shutdown 方法关闭了 Socket 连接，并且所有可用数据均已收到，
    //            * 则 EndReceive 方法将立即完成并返回零字节。
    //            */
    //        SocketError socketError;
    //        num = this.mSocket.EndReceive(ar,out socketError);
    //    }
    //    catch (Exception exception)
    //    {
    //        if (IsConnected())
    //        {
    //            Debug.Log(exception.Message + "接受Socket数据回调时发生错误：" + exception.StackTrace);
    //        }
    //        return;
    //    }
    //    if (num == 0)
    //    {
    //        Debug.Log("接受Socket数据num=0：DisConnect()");
    //        this.DisConnect();
    //    }
    //    else 
    //    {
    //        this.receivePosition += num;
    //        while (true)
    //        {
    //            if (!this.IsConnected()) 
    //            {
    //                break;
    //            }
    //            ByteArray byteArray = new ByteArray();
    //            if (!this.ParseMessage(ref this.receiveBuff, ref this.receivePosition, ref byteArray)) 
    //            {
    //                break;
    //            }
    //            //this.mRecvQueue.Enqueue(byteArray);
    //            //立即处理
    //            _receiveFun(byteArray);
    //        }
    //        this.RecvMessageFromSocket();
    //    }
    //}

    //private bool ParseMessage(ref byte[] buff, ref int len, ref ByteArray byteArray)
    //{
    //    //内容长度2个字节，id 2个字节 ，moduleId 1个字节 methodId 1个字节 checksum 2个字节 = 8,如果当前BUFF总长度不够8个字节，就等待下次再读取
    //    //if (len < 8)
    //    //{
    //    //    return false;
    //    //}
    //    int size = LittleEndianBitConverter.Big.ToInt32(buff, 0);//一条消息协议数据包的长度
    //    if (size < 3 || size > 2048)
    //    {
    //        this.DisConnect();
    //        Debug.Log("数据包大小过长或者较短导致断开连接size=" + size);
    //        return false;
    //    }
    //    if (len < size) //出现粘包情况了，也就是还有一部分数据没有读取到，需要等下次一起读取
    //    {
    //        return false;
    //    }
    //    if (!byteArray.CreateFromSocketBuff(buff, size))
    //    {
    //        RemoveRecvBuff(ref buff, ref len, size+4);
    //        return false;
    //    }
    //    RemoveRecvBuff(ref buff, ref len, size+4);
    //    return true;

    //}

    //private void RemoveRecvBuff(ref byte[] buff, ref int nLen, int nSize)
    //{
    //    if (nSize <= nLen)
    //    {
    //        byte[] destinationArray = new byte[4096];
    //        Array.Copy(buff, nSize, destinationArray, 0, nLen - nSize);//nLen - nSize
    //        //buff = destinationArray;
    //        Array.Copy(destinationArray, 0, buff, 0, nLen - nSize);//nLen - nSize
    //        nLen -= nSize;
    //    }
    //}

	private ushort GetMessageId() {
        if (id >= 30000)
        {
            id = 0;
        }
        return id++;
	}

    public bool Send(OutgoingBase message) 
    {
        if (!this.IsConnected() || message == null)
        {
            return false;
        }
        ByteArray body = new ByteArray();
        //这句是有用的
        //message.fill(body);
        //应该没用了
        //message.seq = GetMessageId();
        //message.write(body);
        uint len = (uint)body.Length - 4;
        var lenBytes = LittleEndianBitConverter.Big.GetBytes(len);
        //由于后端把本身的长度2个字节在基类中已经写入，需要获取新的长度覆盖。
        Array.Copy(lenBytes, body.Buff, 4);
        try 
        {
            SocketError error;
            mSocket.BeginSend(body.Buff, 0, body.Length, SocketFlags.None, out error, new AsyncCallback(this.SendCallback), this);
            isSending = true;
        }
        catch (Exception exception)
        {
            Debug.Log("发送Socket数据发生错误：" + exception.StackTrace);
            return false;
        }
        return true;
    }
    public bool Send(ByteArray body)
    {
        if (!this.IsConnected() || body == null)
        {
            return false;
        }
        //这句是有用的
        //message.fill(body);
        //应该没用了
        //message.seq = GetMessageId();
        //message.write(body);
        uint len = (uint)body.Length - 4;
        var lenBytes = LittleEndianBitConverter.Big.GetBytes(len);
        //由于后端把本身的长度2个字节在基类中已经写入，需要获取新的长度覆盖。
        Array.Copy(lenBytes, body.Buff, 4);
        try
        {
            SocketError error;
            mSocket.BeginSend(body.Buff, 0, body.Length, SocketFlags.None, out error, new AsyncCallback(this.SendCallback), this);
            isSending = true;
        }
        catch (Exception exception)
        {
            Debug.Log("发送Socket数据发生错误：" + exception.StackTrace);
            return false;
        }
        return true;
    }

    private void SendCallback(IAsyncResult ar) 
    {
        try
        {
            SocketError error;
            this.mSocket.EndSend(ar, out error);
            isSending = false;
            _sendFun();
        }
        catch (Exception exception)
        {
            Debug.Log("发送Socket数据回调发生错误：" + exception.StackTrace);
        }
    }

    public ByteArray RecvMessage()
    {
        if (this.mSocket == null)
        {
            return null;
        }
        if (this.mRecvQueue.Count == 0)
        {
            return null;
        }
        ByteArray msg = this.mRecvQueue.Dequeue();
        return msg;
    }

    public int MessageCount
    {
        get { return mRecvQueue.Count; }    
    }

    public void Reset()
    {
        this.mRecvQueue.Clear();
    }
}

class ReceiverThread
{

}
class SenderThread
{

}
