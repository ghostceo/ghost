using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_modify_toc:IncommingBase{
	//ID
	public int protocolID = 1009;

	//fields
	public bool succ = true;
	public string reason;
	public bool return_self = true;
	public p_role_ext info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.info = new p_role_ext();
			this.info.fill2c(ba);
		}
	}
}