using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_recommend_toc:IncommingBase{
	//ID
	public int protocolID = 1019;

	//fields
	public int type = 0;
	public bool succ = true;
	public ArrayList friend_info;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.succ = ba.ReadBoolean();
		this.friend_info = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_recommend_member_info p = new p_recommend_member_info();
			p.fill2c(ba);
			this.friend_info.Add(p);
		}
		this.reason = ba.ReadString();
	}
}