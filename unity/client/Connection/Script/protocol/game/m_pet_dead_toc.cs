using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_dead_toc:IncommingBase{
	//ID
	public int protocolID = 1203;

	//fields
	public int pet_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
	}
}