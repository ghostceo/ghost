using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_refuse_toc:IncommingBase{
	//ID
	public int protocolID = 1011;

	//fields
	public bool succ = true;
	public string name;
	public bool return_self = true;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.name = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		this.reason = ba.ReadString();
	}
}