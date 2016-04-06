using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_nationbattle_rank:GameNetInfo{
	//fields
	public int order = 0;
	public int role_id = 0;
	public string role_name;
	public int faction_id = 0;
	public int role_level = 0;
	public int score = 0;
	public int kill_num = 0;
	public int reward_silver = 0;
	public int jingjie = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.order = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.faction_id = ba.ReadInt();
		this.role_level = ba.ReadInt();
		this.score = ba.ReadInt();
		this.kill_num = ba.ReadInt();
		this.reward_silver = ba.ReadInt();
		this.jingjie = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.order);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.role_level);
		ba.WriteInt(this.score);
		ba.WriteInt(this.kill_num);
		ba.WriteInt(this.reward_silver);
		ba.WriteInt(this.jingjie);
	}
}