using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_share_request_toc:IncommingBase{
	//ID
	public int protocolID = 841;

	//fields
	public int sharer_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.sharer_id = ba.ReadInt();
	}
}