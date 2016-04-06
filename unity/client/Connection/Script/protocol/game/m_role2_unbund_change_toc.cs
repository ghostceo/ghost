using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_unbund_change_toc:IncommingBase{
	//ID
	public int protocolID = 523;

	//fields
	public bool succ = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
	}
}