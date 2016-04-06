using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bigpve_lower_hp_notify_toc:IncommingBase{
	//ID
	public int protocolID = 10609;

	//fields
	public int monster_id = 1;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.monster_id = ba.ReadInt();
	}
}