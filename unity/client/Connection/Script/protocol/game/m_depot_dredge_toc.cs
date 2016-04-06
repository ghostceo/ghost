using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_dredge_toc:IncommingBase{
	//ID
	public int protocolID = 2702;

	//fields
	public bool succ = false;
	public int bagid = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.bagid = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}