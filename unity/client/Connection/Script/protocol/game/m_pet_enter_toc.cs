using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_enter_toc:IncommingBase{
	//ID
	public int protocolID = 1201;

	//fields
	public ArrayList pets;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pets = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_pet p = new p_map_pet();
			p.fill2c(ba);
			this.pets.Add(p);
		}
	}
}