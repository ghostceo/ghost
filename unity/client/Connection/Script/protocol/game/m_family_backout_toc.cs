using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_backout_toc:IncommingBase{
	//ID
	public int protocolID = 3182;

	//fields
	public bool succ = true;
	public string reason;
	public int family_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.family_id = ba.ReadInt();
	}
}