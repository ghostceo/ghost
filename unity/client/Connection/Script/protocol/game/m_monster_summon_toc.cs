using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_monster_summon_toc:IncommingBase{
	//ID
	public int protocolID = 1807;

	//fields
	public int monster_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.monster_id = ba.ReadInt();
	}
}