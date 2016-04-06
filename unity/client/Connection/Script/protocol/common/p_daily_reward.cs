using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_daily_reward:GameNetInfo{
	//fields
	public int id = 0;
	public int type = 0;
	public int min_jingjie = 0;
	public int max_jingjie = 0;
	public int status = 0;
	public int last_fetch_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.type = ba.ReadInt();
		this.min_jingjie = ba.ReadInt();
		this.max_jingjie = ba.ReadInt();
		this.status = ba.ReadInt();
		this.last_fetch_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.type);
		ba.WriteInt(this.min_jingjie);
		ba.WriteInt(this.max_jingjie);
		ba.WriteInt(this.status);
		ba.WriteInt(this.last_fetch_time);
	}
}