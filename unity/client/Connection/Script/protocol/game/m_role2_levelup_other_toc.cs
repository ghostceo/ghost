using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_levelup_other_toc:IncommingBase{
	//ID
	public int protocolID = 503;

	//fields
	public int roleid = 0;
	public int level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
		this.level = ba.ReadInt();
	}
}