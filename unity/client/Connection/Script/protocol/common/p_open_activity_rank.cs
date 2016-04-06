using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_open_activity_rank:GameNetInfo{
	//fields
	public int rank = 0;
	public int role_id = 0;
	public string role_name;
	public double score = 0;
	public int category = 0;
	public int update_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.score = ba.ReadDouble();
		this.category = ba.ReadInt();
		this.update_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rank);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteDouble(this.score);
		ba.WriteInt(this.category);
		ba.WriteInt(this.update_time);
	}
}