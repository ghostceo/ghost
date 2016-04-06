using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_team_nearby:GameNetInfo{
	//fields
	public int team_id = 0;
	public int cur_team_number = 0;
	public int sum_team_number = 0;
	public int role_id = 0;
	public int sex = 0;
	public int faction_id = 0;
	public int level = 0;
	public int category = 0;
	public int skinid = 0;
	public string role_name;
	public bool auto_accept_team = true;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.team_id = ba.ReadInt();
		this.cur_team_number = ba.ReadInt();
		this.sum_team_number = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.sex = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.category = ba.ReadInt();
		this.skinid = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.auto_accept_team = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.team_id);
		ba.WriteInt(this.cur_team_number);
		ba.WriteInt(this.sum_team_number);
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.category);
		ba.WriteInt(this.skinid);
		ba.WriteString(this.role_name);
		ba.WriteBool(this.auto_accept_team);
	}
}