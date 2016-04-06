using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_mission_condition:GameNetInfo{
	//fields
	public int role_id = 0;
	public int faction = 0;
	public int sex = 0;
	public int level = 0;
	public int job = 0;
	public bool has_team = false;
	public bool has_family = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.faction = ba.ReadInt();
		this.sex = ba.ReadInt();
		this.level = ba.ReadInt();
		this.job = ba.ReadInt();
		this.has_team = ba.ReadBoolean();
		this.has_family = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.faction);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.level);
		ba.WriteInt(this.job);
		ba.WriteBool(this.has_team);
		ba.WriteBool(this.has_family);
	}
}