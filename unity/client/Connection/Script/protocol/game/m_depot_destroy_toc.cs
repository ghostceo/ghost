using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_destroy_toc:IncommingBase{
	//ID
	public int protocolID = 2703;

	//fields
	public bool succ = true;
	public string reason;
	public int id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.id = ba.ReadInt();
	}
}