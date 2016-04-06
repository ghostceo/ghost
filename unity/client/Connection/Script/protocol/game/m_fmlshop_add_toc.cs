using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlshop_add_toc:IncommingBase{
	//ID
	public int protocolID = 4902;

	//fields
	public int item_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.item_id = ba.ReadInt();
	}
}