using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_dead_other_toc:IncommingBase{
	//ID
	public int protocolID = 506;

	//fields
	public int roleid = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
	}
}