using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_info_toc:IncommingBase{
	//ID
	public int protocolID = 7403;

	//fields
	public p_role_vip vip_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.vip_info = new p_role_vip();
			this.vip_info.fill2c(ba);
		}
	}
}