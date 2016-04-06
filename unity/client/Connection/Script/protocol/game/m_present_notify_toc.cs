using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_present_notify_toc:IncommingBase{
	//ID
	public int protocolID = 6801;

	//fields
	public ArrayList present_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.present_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_present_info p = new p_present_info();
			p.fill2c(ba);
			this.present_list.Add(p);
		}
	}
}