using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_enable_map_toc:IncommingBase{
	//ID
	public int protocolID = 3133;

	//fields
	public bool succ = true;
	public string reason;
	public bool return_self = true;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
	}
}