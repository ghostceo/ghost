using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_build_list_toc:IncommingBase{
	//ID
	public int protocolID = 847;

	//fields
	public ArrayList list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_shenqi_build p = new p_shenqi_build();
			p.fill2c(ba);
			this.list.Add(p);
		}
	}
}