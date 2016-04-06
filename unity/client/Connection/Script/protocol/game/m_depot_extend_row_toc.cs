using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_extend_row_toc:IncommingBase{
	//ID
	public int protocolID = 2710;

	//fields
	public bool succ = true;
	public int reason_code = 0;
	public int bagid = 0;
	public int rows = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason_code = ba.ReadInt();
		this.bagid = ba.ReadInt();
		this.rows = ba.ReadInt();
	}
}