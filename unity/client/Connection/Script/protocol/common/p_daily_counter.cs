using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_daily_counter:GameNetInfo{
	//fields
	public int id = 0;
	public int remain_times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.remain_times = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.remain_times);
	}
}