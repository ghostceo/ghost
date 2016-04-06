using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_pay_item:GameNetInfo{
	//fields
	public int type = 0;
	public double rmb = 0;
	public int gold = 0;
	public int limit_give_gold = 0;
	public int extra_give_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.rmb = ba.ReadDouble();
		this.gold = ba.ReadInt();
		this.limit_give_gold = ba.ReadInt();
		this.extra_give_gold = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type);
		ba.WriteDouble(this.rmb);
		ba.WriteInt(this.gold);
		ba.WriteInt(this.limit_give_gold);
		ba.WriteInt(this.extra_give_gold);
	}
}