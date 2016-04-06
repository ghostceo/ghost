using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_daily_benefit_expback:GameNetInfo{
	//fields
	public int exp = 0;
	public int remain_count = 0;
	public int exp_status = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.exp = ba.ReadInt();
		this.remain_count = ba.ReadInt();
		this.exp_status = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.exp);
		ba.WriteInt(this.remain_count);
		ba.WriteInt(this.exp_status);
	}
}