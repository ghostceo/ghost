using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_collect_new_toc:IncommingBase{
	//ID
	public int protocolID = 1213;

	//fields
	public p_pet_collect pet_collect;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.pet_collect = new p_pet_collect();
			this.pet_collect.fill2c(ba);
		}
	}
}