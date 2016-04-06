using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_war_my_buffs_toc:IncommingBase{
	//ID
	public int protocolID = 18002;

	//fields
	public ArrayList buffs;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.buffs = new ArrayList();
		ba.ReadIntArray(this.buffs);
	}
}