using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_monster_war_rank:GameNetInfo{
	//fields
	public int rank = 0;
	public int role_id = 0;
	public string role_name;
	public int total_hurts = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.total_hurts = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rank);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.total_hurts);
	}
}