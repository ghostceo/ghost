using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_boss_info_toc:IncommingBase{
	//ID
	public int protocolID = 3181;

	//fields
	public ArrayList boss_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.boss_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_boss_call p = new p_family_boss_call();
			p.fill2c(ba);
			this.boss_list.Add(p);
		}
	}
}