using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_unit_quit_toc:IncommingBase{
	//ID
	public int protocolID = 18203;

	//fields
	public int unitid = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.unitid = ba.ReadInt();
	}
}