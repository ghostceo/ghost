using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_compare_sell_info_toc:IncommingBase{
	//ID
	public int protocolID = 17600;

	//fields
	public ArrayList compare_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.compare_info = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_compare_info p = new p_compare_info();
			p.fill2c(ba);
			this.compare_info.Add(p);
		}
	}
}