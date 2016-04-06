using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_energy_toc:IncommingBase{
	//ID
	public int protocolID = 562;

	//fields
	public int cur_energy = 0;
	public int max_energy = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.cur_energy = ba.ReadInt();
		this.max_energy = ba.ReadInt();
	}
}