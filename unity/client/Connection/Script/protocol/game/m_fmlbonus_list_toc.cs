using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlbonus_list_toc:IncommingBase{
	//ID
	public int protocolID = 20301;

	//fields
	public ArrayList bonus_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.bonus_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_bonus p = new p_family_bonus();
			p.fill2c(ba);
			this.bonus_list.Add(p);
		}
	}
}