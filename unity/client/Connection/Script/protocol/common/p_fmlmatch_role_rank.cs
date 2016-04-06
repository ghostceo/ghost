using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_fmlmatch_role_rank:GameNetInfo{
	//fields
	public int rank = 0;
	public int role_id = 0;
	public string role_name;
	public double role_ftpower = 0;
	public int role_score = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.role_ftpower = ba.ReadDouble();
		this.role_score = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rank);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteDouble(this.role_ftpower);
		ba.WriteInt(this.role_score);
	}
}