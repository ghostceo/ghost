using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_pet_bag:GameNetInfo{
	//fields
	public int role_id = 0;
	public int summoned_pet_id = 0;
	public ArrayList pets;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.summoned_pet_id = ba.ReadInt();
		this.pets = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_pet_id_name p = new p_pet_id_name();
			p.fill2c(ba);
			this.pets.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.summoned_pet_id);
		for (int i = 0; i < pets.Count; i++){
		((p_pet_id_name)this.pets[i]).fill2s(ba);		}
	}
}