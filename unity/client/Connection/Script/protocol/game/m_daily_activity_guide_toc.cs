using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_daily_activity_guide_toc:IncommingBase{
	//ID
	public int protocolID = 18603;

	//fields
	public ArrayList guide_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.guide_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_daily_activity_guide p = new p_daily_activity_guide();
			p.fill2c(ba);
			this.guide_list.Add(p);
		}
	}
}