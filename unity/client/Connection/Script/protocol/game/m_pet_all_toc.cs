using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_all_toc:IncommingBase{
	//ID
	public int protocolID = 1211;

	//fields
	public p_role_pet_bag pet_bag;
	public ArrayList all_pets;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.pet_bag = new p_role_pet_bag();
			this.pet_bag.fill2c(ba);
		}
		this.all_pets = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_pet p = new p_pet();
			p.fill2c(ba);
			this.all_pets.Add(p);
		}
	}
}