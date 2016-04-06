using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_cd_free_notice_toc:IncommingBase{
	//ID
	public int protocolID = 18704;

	//fields
	public int type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
	}
}