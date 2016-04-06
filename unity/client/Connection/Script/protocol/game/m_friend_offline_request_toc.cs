using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_offline_request_toc:IncommingBase{
	//ID
	public int protocolID = 1010;

	//fields
	public ArrayList request_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.request_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_friend_info p = new p_friend_info();
			p.fill2c(ba);
			this.request_list.Add(p);
		}
	}
}