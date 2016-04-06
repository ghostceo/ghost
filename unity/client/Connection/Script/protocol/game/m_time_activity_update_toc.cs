using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_time_activity_update_toc:IncommingBase{
	//ID
	public int protocolID = 19503;

	//fields
	public ArrayList info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.info = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_time_activity p = new p_time_activity();
			p.fill2c(ba);
			this.info.Add(p);
		}
	}
}