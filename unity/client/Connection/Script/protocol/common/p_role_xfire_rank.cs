using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_xfire_rank:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int faction_id = 0;
	public int ranking = 0;
	public string title;
	public double score = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.faction_id = ba.ReadInt();
		this.ranking = ba.ReadInt();
		this.title = ba.ReadString();
		this.score = ba.ReadDouble();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.ranking);
		ba.WriteString(this.title);
		ba.WriteDouble(this.score);
	}
}