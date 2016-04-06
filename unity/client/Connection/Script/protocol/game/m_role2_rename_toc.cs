using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_rename_toc:IncommingBase{
	//ID
	public int protocolID = 544;

	//fields
	public bool succ = true;
	public string reason;
	public int reason_code = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.reason_code = ba.ReadInt();
	}
}