using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_jingjie_rank_yesterday:GameNetInfo{
	//fields
	public int role_id = 0;
	public int ranking = 0;
	public string role_name;
	public int level = 0;
	public int faction_id = 0;
	public int jingjie = 0;
	public int arena_score = 0;
	public int silver = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.ranking = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.level = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.jingjie = ba.ReadInt();
		this.arena_score = ba.ReadInt();
		this.silver = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.ranking);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.level);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.jingjie);
		ba.WriteInt(this.arena_score);
		ba.WriteInt(this.silver);
	}
}