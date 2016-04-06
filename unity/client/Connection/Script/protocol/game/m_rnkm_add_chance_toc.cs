using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rnkm_add_chance_toc:IncommingBase{
	//ID
	public int protocolID = 11209;

	//fields
	public int cost_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.cost_gold = ba.ReadInt();
	}
}