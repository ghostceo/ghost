using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role_add_toc:IncommingBase{
	//ID
	public int protocolID = 402;

	//fields
	public bool succ = true;
	public string reason;
	public int role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.role_id = ba.ReadInt();
	}
}