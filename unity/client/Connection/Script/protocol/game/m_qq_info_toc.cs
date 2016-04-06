using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_qq_info_toc:IncommingBase{
	//ID
	public int protocolID = 9603;

	//fields
	public int zone_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.zone_id = ba.ReadInt();
	}
}