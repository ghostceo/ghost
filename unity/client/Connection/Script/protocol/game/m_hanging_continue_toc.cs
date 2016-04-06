using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_continue_toc:IncommingBase{
	//ID
	public int protocolID = 2314;

	//fields
	public p_battle cur_battle;
	public int left_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.cur_battle = new p_battle();
			this.cur_battle.fill2c(ba);
		}
		this.left_time = ba.ReadInt();
	}
}