using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_equip_rank:GameNetInfo{
	//fields
	public int goods_id = 0;
	public string role_name;
	public int type_id = 0;
	public int colour = 0;
	public int quality = 0;
	public int ranking = 0;
	public int faction_id = 0;
	public int refining_score = 0;
	public int reinforce_score = 0;
	public int stone_score = 0;
	public int role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.goods_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.type_id = ba.ReadInt();
		this.colour = ba.ReadInt();
		this.quality = ba.ReadInt();
		this.ranking = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.refining_score = ba.ReadInt();
		this.reinforce_score = ba.ReadInt();
		this.stone_score = ba.ReadInt();
		this.role_id = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.goods_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.type_id);
		ba.WriteInt(this.colour);
		ba.WriteInt(this.quality);
		ba.WriteInt(this.ranking);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.refining_score);
		ba.WriteInt(this.reinforce_score);
		ba.WriteInt(this.stone_score);
		ba.WriteInt(this.role_id);
	}
}