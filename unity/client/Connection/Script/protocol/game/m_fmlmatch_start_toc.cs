using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlmatch_start_toc:IncommingBase{
	//ID
	public int protocolID = 20403;

	//fields
	public int view_role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.view_role_id = ba.ReadInt();
	}
}