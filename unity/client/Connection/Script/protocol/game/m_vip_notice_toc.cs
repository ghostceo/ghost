using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_notice_toc:IncommingBase{
	//ID
	public int protocolID = 7413;

	//fields
	public bool active = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.active = ba.ReadBoolean();
	}
}