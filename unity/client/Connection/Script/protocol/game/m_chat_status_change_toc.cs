using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_status_change_toc:IncommingBase{
	//ID
	public int protocolID = 915;

	//fields
	public int role_id = 0;
	public string channel_sign;
	public int channel_type = 0;
	public int status = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.channel_sign = ba.ReadString();
		this.channel_type = ba.ReadInt();
		this.status = ba.ReadInt();
	}
}