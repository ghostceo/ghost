using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_in_channel_tos:OutgoingBase{
	//ID
	public int protocolID = 902;

	//fields
	public string channel_sign;
	public string msg;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(902);
		ba.WriteString(this.channel_sign);
		ba.WriteString(this.msg);
	}
}