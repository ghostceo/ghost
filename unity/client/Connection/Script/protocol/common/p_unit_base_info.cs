using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_unit_base_info:GameNetInfo{
	//fields
	public int typeid = 0;
	public int unit_type = 0;
	public int max_hp = 0;
	public string name;
	public int max_attack = 0;
	public int min_attack = 0;
	public int physical_defence = 0;
	public int magic_defence = 0;
	public int attack_speed = 0;
	public int radius = 0;
	public ArrayList datas;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.typeid = ba.ReadInt();
		this.unit_type = ba.ReadInt();
		this.max_hp = ba.ReadInt();
		this.name = ba.ReadString();
		this.max_attack = ba.ReadInt();
		this.min_attack = ba.ReadInt();
		this.physical_defence = ba.ReadInt();
		this.magic_defence = ba.ReadInt();
		this.attack_speed = ba.ReadInt();
		this.radius = ba.ReadInt();
		this.datas = new ArrayList();
		ba.ReadIntArray(this.datas);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.typeid);
		ba.WriteInt(this.unit_type);
		ba.WriteInt(this.max_hp);
		ba.WriteString(this.name);
		ba.WriteInt(this.max_attack);
		ba.WriteInt(this.min_attack);
		ba.WriteInt(this.physical_defence);
		ba.WriteInt(this.magic_defence);
		ba.WriteInt(this.attack_speed);
		ba.WriteInt(this.radius);
		ba.WriteIntArray(this.datas);
	}
}