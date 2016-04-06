using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_change_toc:IncommingBase{
	//ID
	public int protocolID = 2306;

	//fields
	public p_battle next_battle;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.next_battle = new p_battle();
			this.next_battle.fill2c(ba);
		}
	}
}