using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_notice_end_toc:IncommingBase{
	//ID
	public int protocolID = 5612;

	//fields
	public int activity_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.activity_id = ba.ReadInt();
	}
}