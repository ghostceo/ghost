using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_level_rank:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int faction_id = 0;
	public string family_name;
	public int level = 0;
	public int ranking = 0;
	public string title;
	public double exp = 0;
	public int category = 0;
	public double fight_power = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.faction_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.level = ba.ReadInt();
		this.ranking = ba.ReadInt();
		this.title = ba.ReadString();
		this.exp = ba.ReadDouble();
		this.category = ba.ReadInt();
		this.fight_power = ba.ReadDouble();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.faction_id);
		ba.WriteString(this.family_name);
		ba.WriteInt(this.level);
		ba.WriteInt(this.ranking);
		ba.WriteString(this.title);
		ba.WriteDouble(this.exp);
		ba.WriteInt(this.category);
		ba.WriteDouble(this.fight_power);
	}
}