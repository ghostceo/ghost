using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_add_black_toc:IncommingBase{
	//ID
	public int protocolID = 909;

	//fields
	public bool succ = false;
	public string reason;
	public p_chat_role role_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.role_info = new p_chat_role();
			this.role_info.fill2c(ba);
		}
	}
}