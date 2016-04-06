using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_skin:GameNetInfo{
	//fields
	public int skinid = 0;
	public int hair_type = 0;
	public int hair_color;
	public int weapon = 0;
	public int clothes = 0;
	public int mounts = 0;
	public int assis_weapon = 0;
	public int fashion = 0;
	public ArrayList light_code;
	public int fashion_wing = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.skinid = ba.ReadInt();
		this.hair_type = ba.ReadInt();
		this.hair_color = ba.ReadInt();
		this.weapon = ba.ReadInt();
		this.clothes = ba.ReadInt();
		this.mounts = ba.ReadInt();
		this.assis_weapon = ba.ReadInt();
		this.fashion = ba.ReadInt();
		this.light_code = new ArrayList();
		ba.ReadIntArray(this.light_code);
		this.fashion_wing = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.skinid);
		ba.WriteInt(this.hair_type);
		ba.WriteInt(this.hair_color);
		ba.WriteInt(this.weapon);
		ba.WriteInt(this.clothes);
		ba.WriteInt(this.mounts);
		ba.WriteInt(this.assis_weapon);
		ba.WriteInt(this.fashion);
		ba.WriteIntArray(this.light_code);
		ba.WriteInt(this.fashion_wing);
	}
}