using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_rnkm_mirror:GameNetInfo{
	//fields
	public int rank = 0;
	public int role_id = 0;
	public string role_name;
	public int sex = 0;
	public int fight_power = 0;
	public int category = 0;
	public int status = 0;
	public int level = 0;
	public int sanyuan = 0;
	public int grab_rate = 0;
	public bool can_fast_fight = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.sex = ba.ReadInt();
		this.fight_power = ba.ReadInt();
		this.category = ba.ReadInt();
		this.status = ba.ReadInt();
		this.level = ba.ReadInt();
		this.sanyuan = ba.ReadInt();
		this.grab_rate = ba.ReadInt();
		this.can_fast_fight = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rank);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.fight_power);
		ba.WriteInt(this.category);
		ba.WriteInt(this.status);
		ba.WriteInt(this.level);
		ba.WriteInt(this.sanyuan);
		ba.WriteInt(this.grab_rate);
		ba.WriteBool(this.can_fast_fight);
	}
}