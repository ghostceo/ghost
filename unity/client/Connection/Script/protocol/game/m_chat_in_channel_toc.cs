using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_in_channel_toc:IncommingBase{
	//ID
	public int protocolID = 902;

	//fields
	public bool succ = true;
	public string reason;
	public string channel_sign;
	public string msg;
	public p_chat_role role_info;
	public int tstamp = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.channel_sign = ba.ReadString();
		this.msg = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.role_info = new p_chat_role();
			this.role_info.fill2c(ba);
		}
		this.tstamp = ba.ReadInt();
	}
}