using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_holiday_gold_act_history:GameNetInfo{
	//fields
	public string role_name;
	public int cost_gold = 0;
	public int return_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_name = ba.ReadString();
		this.cost_gold = ba.ReadInt();
		this.return_gold = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteString(this.role_name);
		ba.WriteInt(this.cost_gold);
		ba.WriteInt(this.return_gold);
	}
}