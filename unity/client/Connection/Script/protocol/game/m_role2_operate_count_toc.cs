using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_operate_count_toc:IncommingBase{
	//ID
	public int protocolID = 565;

	//fields
	public int type = 0;
	public int count = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.count = ba.ReadInt();
	}
}