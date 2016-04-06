using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_accept_or_refuse_toc:IncommingBase{
	//ID
	public int protocolID = 1031;

	//fields
	public bool succ = true;
	public string name;
	public string reason;
	public bool return_self = true;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.name = ba.ReadString();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
	}
}