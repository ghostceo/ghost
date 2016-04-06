using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_base_reload_toc:IncommingBase{
	//ID
	public int protocolID = 519;

	//fields
	public p_role_base role_base;
	public double fight_power = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.role_base = new p_role_base();
			this.role_base.fill2c(ba);
		}
		this.fight_power = ba.ReadDouble();
	}
}