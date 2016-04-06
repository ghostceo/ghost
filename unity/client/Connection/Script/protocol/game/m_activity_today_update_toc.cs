using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_today_update_toc:IncommingBase{
	//ID
	public int protocolID = 5619;

	//fields
	public p_activity_info info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.info = new p_activity_info();
			this.info.fill2c(ba);
		}
	}
}