using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_config_change_toc:IncommingBase{
	//ID
	public int protocolID = 3603;

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