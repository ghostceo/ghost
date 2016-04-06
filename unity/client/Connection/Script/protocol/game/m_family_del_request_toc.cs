using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_del_request_toc:IncommingBase{
	//ID
	public int protocolID = 3163;

	//fields
	public int role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
	}
}