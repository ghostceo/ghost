using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_daily_present_toc:IncommingBase{
	//ID
	public int protocolID = 550;

	//fields
	public int msg_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.msg_type = ba.ReadInt();
	}
}