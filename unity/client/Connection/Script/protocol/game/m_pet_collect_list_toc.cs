using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_collect_list_toc:IncommingBase{
	//ID
	public int protocolID = 1209;

	//fields
	public int category = 0;
	public ArrayList pet_collects;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.category = ba.ReadInt();
		this.pet_collects = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_pet_collect p = new p_pet_collect();
			p.fill2c(ba);
			this.pet_collects.Add(p);
		}
	}
}