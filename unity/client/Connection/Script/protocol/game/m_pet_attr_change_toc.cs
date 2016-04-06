using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_attr_change_toc:IncommingBase{
	//ID
	public int protocolID = 1204;

	//fields
	public int pet_id = 0;
	public int change_type = 0;
	public double value = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.change_type = ba.ReadInt();
		this.value = ba.ReadDouble();
	}
}