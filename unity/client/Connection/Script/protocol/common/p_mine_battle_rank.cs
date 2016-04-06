using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_mine_battle_rank:GameNetInfo{
	//fields
	public int role_id = 0;
	public int ranking = 0;
	public string role_name;
	public int level = 0;
	public int color = 0;
	public int score = 0;
	public int faction_id = 0;
	public int fightpower = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.ranking = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.level = ba.ReadInt();
		this.color = ba.ReadInt();
		this.score = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.fightpower = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.ranking);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.level);
		ba.WriteInt(this.color);
		ba.WriteInt(this.score);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.fightpower);
	}
}