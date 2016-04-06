using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_achievement_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 16801;

	//fields
	public p_role_achievement info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.info = new p_role_achievement();
			this.info.fill2c(ba);
		}
	}
}