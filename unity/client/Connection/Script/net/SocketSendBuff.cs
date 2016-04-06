
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Collections;
using System.Net;
using System.Net.Sockets;

public class SocketSendBuff{
   
   public Thread thread = null;
    
    public Socket sock = null;
	public Queue< List<byte> > queue;
	
	public bool running = true;
	
	public OnDisconnectDelegate onDisconnect = null;
	
   	public SocketSendBuff(Socket sock,Queue< List<byte> > queue,OnDisconnectDelegate onDisconnect = null){
   	   
   	   	this.sock = sock;
		this.queue = queue;	
		this.onDisconnect = onDisconnect;
        this.running = true;
	    this.thread = new Thread(new ThreadStart(this.run));
		this.thread.IsBackground = true; //back group.for main thread dead,i dead.
	    this.thread.Start();
	}
    public void close()
    {
        if (this.running)
        {
            this.running = false;
            this.queue.Clear();
        }
    }
   public void run()
    { 
       while(this.running){
          lock(this.queue)
		  {				
		      if( this.queue.Count > 0)
              {		         
		           List<byte> buffer = new List<byte>();
			       foreach (List<byte> buf in this.queue)
				   {					
						buffer.AddRange(buf);
				   }
				   this.queue.Clear();
				   
				   if(buffer.Count > 0)
                   {				      
					   try {
							byte[] send_buf = buffer.ToArray();
							int send_offset = 0;							
							while (true)
							{
                                if (!this.running)
                                    break;
								int sendCount = sock.Send (send_buf, send_offset, buffer.Count - send_offset, SocketFlags.None);
								
								send_offset += sendCount;
							
								if(sendCount == 0)
                                {								   
									//send error disconnect
									if(this.onDisconnect != null)
                                    {
                                        Debug.Log("send onDisconnect1");
								        this.onDisconnect(this.sock);
								    }   
									this.running = false;
									break;
								}
								else if (send_offset >= buffer.Count)
								{
									break;
								}                                
							}
							
						} catch (Exception e) {
                            Debug.Log("send exception:" + e.Message);						   
							//send exception disconnect
							if(this.onDisconnect != null){
                                Debug.Log("send onDisconnect2");
							      this.onDisconnect(this.sock);
							}
							this.running = false;
							break;
	 				    }
				   }
				 
		      } //if( this.queue.Count > 0){
		      
		  } //lock(this.queue)
		  
          Thread.Sleep(10); //10   (unit = second /1000)
          
       } // while(this.running){
       if (!this.running)
       {
           this.thread.Abort();
       }
    }
}
