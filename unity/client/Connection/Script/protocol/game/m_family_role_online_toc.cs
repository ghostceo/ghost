using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_role_online_toc:IncommingBase{
	//ID
	public int protocolID = 3129;

	//fields
	public int role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
	}
}