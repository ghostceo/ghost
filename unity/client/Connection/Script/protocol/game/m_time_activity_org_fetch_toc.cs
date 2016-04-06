using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_time_activity_org_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 19504;

	//fields
	public int activity_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.activity_id = ba.ReadInt();
	}
}