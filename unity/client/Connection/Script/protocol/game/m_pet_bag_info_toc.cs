using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_bag_info_toc:IncommingBase{
	//ID
	public int protocolID = 1208;

	//fields
	public p_role_pet_bag info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.info = new p_role_pet_bag();
			this.info.fill2c(ba);
		}
	}
}