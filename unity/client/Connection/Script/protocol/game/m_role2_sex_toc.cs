using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_sex_toc:IncommingBase{
	//ID
	public int protocolID = 527;

	//fields
	public bool succ = true;
	public int sex = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.sex = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}