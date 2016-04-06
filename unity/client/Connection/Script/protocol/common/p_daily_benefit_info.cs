using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_daily_benefit_info:GameNetInfo{
	//fields
	public int id = 0;
	public int reward_status = 0;
	public int param = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.reward_status = ba.ReadInt();
		this.param = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.reward_status);
		ba.WriteInt(this.param);
	}
}