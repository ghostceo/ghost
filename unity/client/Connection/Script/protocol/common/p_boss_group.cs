using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_boss_group:GameNetInfo{
	//fields
	public int boss_id = 0;
	public int status = 0;
	public int start_time = 0;
	public int end_time = 0;
	public int map_id = 0;
	public int tx = 0;
	public int ty = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.boss_id = ba.ReadInt();
		this.status = ba.ReadInt();
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.map_id = ba.ReadInt();
		this.tx = ba.ReadInt();
		this.ty = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.boss_id);
		ba.WriteInt(this.status);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.map_id);
		ba.WriteInt(this.tx);
		ba.WriteInt(this.ty);
	}
}