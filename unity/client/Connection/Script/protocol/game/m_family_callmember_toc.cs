using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_callmember_toc:IncommingBase{
	//ID
	public int protocolID = 3139;

	//fields
	public int call_type = 0;
	public bool succ = true;
	public string reason;
	public string message;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.call_type = ba.ReadInt();
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.message = ba.ReadString();
	}
}