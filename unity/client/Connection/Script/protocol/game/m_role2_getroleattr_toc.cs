using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_getroleattr_toc:IncommingBase{
	//ID
	public int protocolID = 510;

	//fields
	public bool succ = true;
	public string reason;
	public p_other_role_info role_info;
	public p_role_pet_bag pet_bag;
	public ArrayList all_pets;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.role_info = new p_other_role_info();
			this.role_info.fill2c(ba);
		}
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