using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_notify_online_toc:IncommingBase{
	//ID
	public int protocolID = 3173;

	//fields
	public bool succ = true;
	public string reason;
	public ArrayList online_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.online_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_member_info p = new p_family_member_info();
			p.fill2c(ba);
			this.online_list.Add(p);
		}
	}
}