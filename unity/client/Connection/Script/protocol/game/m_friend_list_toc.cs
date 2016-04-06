using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_list_toc:IncommingBase{
	//ID
	public int protocolID = 1007;

	//fields
	public bool succ = true;
	public ArrayList friend_list;
	public string reason;
	public int cur_friend = 0;
	public int max_friend = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.friend_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_friend_info p = new p_friend_info();
			p.fill2c(ba);
			this.friend_list.Add(p);
		}
		this.reason = ba.ReadString();
		this.cur_friend = ba.ReadInt();
		this.max_friend = ba.ReadInt();
	}
}