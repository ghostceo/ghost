using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_examine_fb_barrier:GameNetInfo{
	//fields
	public int barrier_id = 0;
	public int status = 0;
	public int fight_times = 0;
	public ArrayList score_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.barrier_id = ba.ReadInt();
		this.status = ba.ReadInt();
		this.fight_times = ba.ReadInt();
		this.score_list = new ArrayList();
		ba.ReadIntArray(this.score_list);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.barrier_id);
		ba.WriteInt(this.status);
		ba.WriteInt(this.fight_times);
		ba.WriteIntArray(this.score_list);
	}
}