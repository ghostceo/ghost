using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_notice_toc:IncommingBase{
	//ID
	public int protocolID = 566;

	//fields
	public int notice_type = 0;
	public int times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.notice_type = ba.ReadInt();
		this.times = ba.ReadInt();
	}
}