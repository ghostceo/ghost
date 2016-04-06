using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_leave_channel_toc:IncommingBase{
	//ID
	public int protocolID = 904;

	//fields
	public string channel_sign;
	public int channel_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.channel_sign = ba.ReadString();
		this.channel_type = ba.ReadInt();
	}
}