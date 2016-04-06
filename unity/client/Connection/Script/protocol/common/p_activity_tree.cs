using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_activity_tree:GameNetInfo{
	//fields
	public int status = 0;
	public int reap_times = 0;
	public int total_reap_times = 0;
	public int rem_next_reap_time = 0;
	public ArrayList collect_goods;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.status = ba.ReadInt();
		this.reap_times = ba.ReadInt();
		this.total_reap_times = ba.ReadInt();
		this.rem_next_reap_time = ba.ReadInt();
		this.collect_goods = new ArrayList();
		ba.ReadIntArray(this.collect_goods);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.status);
		ba.WriteInt(this.reap_times);
		ba.WriteInt(this.total_reap_times);
		ba.WriteInt(this.rem_next_reap_time);
		ba.WriteIntArray(this.collect_goods);
	}
}