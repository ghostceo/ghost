namespace LSocket.Net 
{

    // 描   述：封装c# socket数据传输协议 
  	using UnityEngine; 
	using System; 
	using System.Net.Sockets; 
	using System.Net; 
	using System.Collections;
    using System.Collections.Generic; 
	using System.Text;
    using System.Threading;
	using LSocket.Type; 
	using LSocket.cmd;
	using LSocket.Test;
    using LSocket.erl;
    //using LSocket.Common;


    class SocketThread
    {

        UnitySocket socket;
        SocketDemo demo;
        int idx;

        public SocketThread(UnitySocket socket, SocketDemo demo, int idx)
        {
            this.socket = socket;
            this.demo = demo;
            this.idx = idx;
        }

        public void run()
        {
            while (true)
            {
                try
                {
                    String s = socket.RecMessage();
                    demo.textAreaString[idx * 3] = demo.textAreaString[idx * 3 + 1];
                    demo.textAreaString[idx * 3 + 1] = demo.textAreaString[idx * 3 + 2];
                    demo.textAreaString[idx * 3 + 2] = s;
					Debug.Log(s + " " + idx);
                }
                catch (Exception e)
                {
                    Debug.Log(e.ToString());
                    socket.t.Abort();
                }
            }
        }

    }

    public class UnitySocket 
    { 
        public Socket mSocket = null;
        public Thread t=null;
        private SocketThread st=null;
        public SocketDemo demo=null;

        public UnitySocket() 
        { 
             
        } 
		public void SocketConnection(string LocalIP, int LocalPort,SocketDemo demo,int idx) 
		{
            this.demo=demo;
			mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            try 
            { 
				 
                IPAddress ip = IPAddress.Parse(LocalIP); 
                IPEndPoint ipe = new IPEndPoint(ip, LocalPort); 
				mSocket.Connect(ipe);
                st =new SocketThread(this, demo, idx);
                t = new Thread(new ThreadStart(st.run));
                t.Start();
            } 
            catch (Exception e) 
            {
                MonoBehaviour.print(e.ToString());
            } 
		}
        
        public void close(){
            mSocket.Close(0);
            mSocket=null;
        }

        public void DoLogin(String userName){
            try
            {
                // starthandclasp();
                // Send(CommandID.LOGIN);
                // Debug.Log(userName);
                // Send(CommandID.GUIGUI);
                // Send(CommandID.ZIYI);
                Send(CommandID.MODULE);
                Send(CommandID.METHOD);
                Send("{m_money_tree_fetch_tos,1}");
                // Send(userName);
            }catch(Exception e){
                MonoBehaviour.print(e.ToString());
            }
        }

		public void DoTest(){
		    try
            {   
               List<byte> test = new List<byte>();
               byte[] unique   = TypeConvert.getBytes((short)258,true);
               test.AddRange(unique);
               byte[] moduleId = TypeConvert.getBytes(CommandID.MODULE,true);
               test.AddRange(moduleId);
               byte[] methodId = TypeConvert.getBytes(CommandID.METHOD,true);
               test.AddRange(methodId);
               byte[] tuple = TypeConvert.getBytes(ErlangTy.TUPLE,true);
               test.AddRange(tuple);
               byte[] tlenx  = TypeConvert.getBytes(ErlangTy.MIN,true);
               test.AddRange(tlenx);
               byte[] tleny  = TypeConvert.getBytes((byte)2,true);
               test.AddRange(tleny);
               byte[] tatom  = TypeConvert.getBytes(ErlangTy.TATOM,true);
               test.AddRange(tatom);
               string s = "m_money_tree_fetch_tos"; 
               int len = s.Length;
               byte[] lens  = TypeConvert.getBytes((short)len,true);
               test.AddRange(lens);
               byte[] bodys = Encoding.UTF8.GetBytes(s);
               test.AddRange(bodys);
               byte[] tint  = TypeConvert.getBytes(ErlangTy.INT32,true);
               test.AddRange(tint);
               int num = 1;
               byte[] tnum  = TypeConvert.getBytes((byte)num,true);
               test.AddRange(tnum);
               SendMsg(test);
               Debug.Log("over");

            } catch(Exception e){
                MonoBehaviour.print(e.ToString());
            }

		}


        public void DoBin(){
            try
            {   
                m_activity_fecth_tos ras = new m_activity_fecth_tos();
                ras.npc_id = 16;
                SendMessage(ras);
            } catch(Exception e){
                MonoBehaviour.print(e.ToString());
            }
        }

        public void Send(float data){
            byte[] longth = TypeConvert.getBytes(data, true);
            mSocket.Send(longth);
        }

        public float ReceiveFloat()
        {
            byte[] recvBytes = new byte[4];
            mSocket.Receive(recvBytes, 4, 0);//从服务器端接受返回信息 
            float data = TypeConvert.getFloat(recvBytes, true);
            return data;
        } 

		public void Send(short data) 
		{ 
			byte[] longth=TypeConvert.getBytes(data,true); 
			mSocket.Send(longth);
		} 
		 
		public void Send(long data) 
		{ 
			byte[] longth=TypeConvert.getBytes(data,true); 
			mSocket.Send(longth); 
		} 
		 
		public void Send(int data) 
		{ 
			byte[] longth=TypeConvert.getBytes(data,true); 
			mSocket.Send(longth); 
			 
		} 
		 
		public void Send(string data) 
		{ 
			byte[] longth=Encoding.UTF8.GetBytes(data);
            Send(longth.Length);
			mSocket.Send(longth); 
			 
		}


        public void Send(ByteArray body)
        {
            int len = body.Length;
            ByteBuffer msg = ByteBuffer.Allocate(len);
            Array.Copy(body.Buff, 0, msg.buf, 0, len);
            mSocket.Send(msg.buf);
        }

        public void SendMsg(List<byte> data)
        {
            ByteBuffer msg = ByteBuffer.Allocate(data.Count);
            foreach(byte submsg in data)
            {
                msg.WriteByte(submsg);
            }
            mSocket.Send(msg.buf);
        }

        // public void Test(short id,short moduleId,short methodId,string msg)
        // {       
        //         byte[] test = new byte[];
        //         ByteBuffer buf = ByteBuffer.Allocate(test);
        //         buf.WriteShort(id);
        //         buf.WriteByte(moduleId);
        //         buf.WriteShort(methodId);
        //         byte[] longth=Encoding.UTF8.GetBytes(msg);
        //         buf.WriteByte(131);
        //         buf.WriteBytes(longth);
        //         mSocket.Send(buf);
        // } 
		 
		public short ReceiveShort() 
		{ 
			 byte[] recvBytes = new byte[2]; 
             mSocket.Receive(recvBytes,2,0);//从服务器端接受返回信息 
			 short data=TypeConvert.getShort(recvBytes,true); 
			 return data; 
		} 
		 
		public int ReceiveInt() 
		{ 
			 byte[] recvBytes = new byte[4]; 
             mSocket.Receive(recvBytes,4,0);//从服务器端接受返回信息 
			 int data=TypeConvert.getInt(recvBytes,true); 
			 return data; 
		} 
		 
		public long ReceiveLong() 
		{ 
			 byte[] recvBytes = new byte[8]; 
             mSocket.Receive(recvBytes,8,0);//从服务器端接受返回信息 
			 long data=TypeConvert.getLong(recvBytes,true); 
			 return data; 
		} 
		 
		public String ReceiveString() 
		{ 
             int length = ReceiveInt();
             Debug.Log("Stringlen="+length);
			 byte[] recvBytes = new byte[length]; 
             mSocket.Receive(recvBytes,length,0);//从服务器端接受返回信息
             String data = Encoding.UTF8.GetString(recvBytes); 
			 return data; 
		}


        public String RecMessage() 
        { 
             int length = ReceiveInt();
             Debug.Log("Stringlen="+length);
             byte[] recvBytes = new byte[length];
             mSocket.Receive(recvBytes,0,length,0);//从服务器端接受返回信息 
             ByteBuffer msg = ByteBuffer.Allocate(length);
             Array.Copy(recvBytes, 0, msg.buf, 0, length);
             uint Method = msg.ReadUint();
             uint Mlv = msg.ReadUint();
             Debug.Log("Sn="+Method);
             Debug.Log("Stn="+Mlv);
             String data = "haha";
             return data; 
        }


        public void SendMessage(OutgoingBase message)
            {
                ByteArray byteArray = new ByteArray();
                message.fill2s(byteArray);
                Send(byteArray);
            }

        // private void starthandclasp()
        // {    
        //     byte[] ba = new byte[23];
        //     public short num =  23;
        //     mSocket.Send(num);
        //     mSocket.Send(ba);
        // } 
		 
	}
} 
