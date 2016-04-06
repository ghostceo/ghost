using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_caishen_coin:GameNetInfo{
	//fields
	public int max_num = 0;
	public int fetch_num = 0;
	public int per_num = 0;
	public int cost_gold = 0;
	public int get_coin = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.max_num = ba.ReadInt();
		this.fetch_num = ba.ReadInt();
		this.per_num = ba.ReadInt();
		this.cost_gold = ba.ReadInt();
		this.get_coin = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.max_num);
		ba.WriteInt(this.fetch_num);
		ba.WriteInt(this.per_num);
		ba.WriteInt(this.cost_gold);
		ba.WriteInt(this.get_coin);
	}
}