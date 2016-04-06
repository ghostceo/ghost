using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_unit_enter_toc:IncommingBase{
	//ID
	public int protocolID = 18202;

	//fields
	public ArrayList units;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.units = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_unit p = new p_map_unit();
			p.fill2c(ba);
			this.units.Add(p);
		}
	}
}