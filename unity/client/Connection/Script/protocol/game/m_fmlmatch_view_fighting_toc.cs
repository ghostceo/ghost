using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlmatch_view_fighting_toc:IncommingBase{
	//ID
	public int protocolID = 20402;

	//fields
	public p_hanging_round hanging_round;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.hanging_round = new p_hanging_round();
			this.hanging_round.fill2c(ba);
		}
	}
}