using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_remove_skin_buff_toc:IncommingBase{
	//ID
	public int protocolID = 535;

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