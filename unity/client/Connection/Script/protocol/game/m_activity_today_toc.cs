using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_today_toc:IncommingBase{
	//ID
	public int protocolID = 5601;

	//fields
	public bool succ = true;
	public string reason;
	public ArrayList activity_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.activity_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_activity_info p = new p_activity_info();
			p.fill2c(ba);
			this.activity_list.Add(p);
		}
	}
}