using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_join_channel_toc:IncommingBase{
	//ID
	public int protocolID = 908;

	//fields
	public p_channel_info channel_info;
	public p_chat_role role_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.channel_info = new p_channel_info();
			this.channel_info.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.role_info = new p_chat_role();
			this.role_info.fill2c(ba);
		}
	}
}