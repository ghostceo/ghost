using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_build_refresh_toc:IncommingBase{
	//ID
	public int protocolID = 833;

	//fields
	public p_goods equip;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.equip = new p_goods();
			this.equip.fill2c(ba);
		}
	}
}