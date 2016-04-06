using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_getgift_toc:IncommingBase{
	//ID
	public int protocolID = 5608;

	//fields
	public bool succ = true;
	public string reason;
	public int type = 0;
	public int id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.type = ba.ReadInt();
		this.id = ba.ReadInt();
	}
}