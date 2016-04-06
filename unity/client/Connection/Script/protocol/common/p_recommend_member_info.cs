using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_recommend_member_info:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int level = 0;
	public int sex = 0;
	public int category = 0;
	public int head = 0;
	public int faction_id = 0;
	public int fightpower = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.level = ba.ReadInt();
		this.sex = ba.ReadInt();
		this.category = ba.ReadInt();
		this.head = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.fightpower = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.level);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.category);
		ba.WriteInt(this.head);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.fightpower);
	}
}