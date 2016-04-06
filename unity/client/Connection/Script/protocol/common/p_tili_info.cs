using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_tili_info:GameNetInfo{
	//fields
	public int cur_tili = 0;
	public int max_tili = 0;
	public int can_buy_tili = 0;
	public int today_buy_times = 0;
	public int max_buy_times = 0;
	public int buy_need_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.cur_tili = ba.ReadInt();
		this.max_tili = ba.ReadInt();
		this.can_buy_tili = ba.ReadInt();
		this.today_buy_times = ba.ReadInt();
		this.max_buy_times = ba.ReadInt();
		this.buy_need_gold = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.cur_tili);
		ba.WriteInt(this.max_tili);
		ba.WriteInt(this.can_buy_tili);
		ba.WriteInt(this.today_buy_times);
		ba.WriteInt(this.max_buy_times);
		ba.WriteInt(this.buy_need_gold);
	}
}