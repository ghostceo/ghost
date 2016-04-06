using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_pve_fb_buff_info:GameNetInfo{
	//fields
	public int type = 0;
	public int money_type = 0;
	public int cost_money = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.money_type = ba.ReadInt();
		this.cost_money = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type);
		ba.WriteInt(this.money_type);
		ba.WriteInt(this.cost_money);
	}
}