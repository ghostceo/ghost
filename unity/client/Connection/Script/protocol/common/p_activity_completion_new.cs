using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_activity_completion_new:GameNetInfo{
	//fields
	public int activity_id = 0;
	public int max_times = 0;
	public int cur_times = 0;
	public int add_activity = 0;
	public int flush_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.activity_id = ba.ReadInt();
		this.max_times = ba.ReadInt();
		this.cur_times = ba.ReadInt();
		this.add_activity = ba.ReadInt();
		this.flush_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.activity_id);
		ba.WriteInt(this.max_times);
		ba.WriteInt(this.cur_times);
		ba.WriteInt(this.add_activity);
		ba.WriteInt(this.flush_time);
	}
}