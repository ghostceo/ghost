using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_fmlmatch_role:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int role_level = 0;
	public double role_ftpower = 0;
	public int family_id = 0;
	public string family_name;
	public int summoned_pet_category = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.role_level = ba.ReadInt();
		this.role_ftpower = ba.ReadDouble();
		this.family_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.summoned_pet_category = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.role_level);
		ba.WriteDouble(this.role_ftpower);
		ba.WriteInt(this.family_id);
		ba.WriteString(this.family_name);
		ba.WriteInt(this.summoned_pet_category);
	}
}