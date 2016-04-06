using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_call_partyboss_toc:IncommingBase{
	//ID
	public int protocolID = 3176;

	//fields
	public bool succ = true;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
	}
}