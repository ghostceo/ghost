using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_activity_info:GameNetInfo{
	//fields
	public int id = 0;
	public int type = 0;
	public int order_id = 0;
	public int status = 0;
	public int done_times = 0;
	public int total_times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.type = ba.ReadInt();
		this.order_id = ba.ReadInt();
		this.status = ba.ReadInt();
		this.done_times = ba.ReadInt();
		this.total_times = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.type);
		ba.WriteInt(this.order_id);
		ba.WriteInt(this.status);
		ba.WriteInt(this.done_times);
		ba.WriteInt(this.total_times);
	}
}