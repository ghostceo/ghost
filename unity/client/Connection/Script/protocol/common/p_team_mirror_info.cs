using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_team_mirror_info:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int level = 0;
	public int category = 0;
	public int sanyuan = 0;
	public double fight_power = 0;
	public bool is_friend = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.level = ba.ReadInt();
		this.category = ba.ReadInt();
		this.sanyuan = ba.ReadInt();
		this.fight_power = ba.ReadDouble();
		this.is_friend = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.level);
		ba.WriteInt(this.category);
		ba.WriteInt(this.sanyuan);
		ba.WriteDouble(this.fight_power);
		ba.WriteBool(this.is_friend);
	}
}