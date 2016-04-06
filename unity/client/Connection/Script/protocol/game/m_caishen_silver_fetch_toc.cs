using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_caishen_silver_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 10002;

	//fields
	public bool succ = false;
	public int err_code = 0;
	public int times = 0;
	public int cost_gold = 0;
	public int get_coin = 0;
	public int cost_item_num = 0;
	public p_caishen_coin caishen_info;
	public int left_item_num = 0;
	public int remain_cnt = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.err_code = ba.ReadInt();
		this.times = ba.ReadInt();
		this.cost_gold = ba.ReadInt();
		this.get_coin = ba.ReadInt();
		this.cost_item_num = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.caishen_info = new p_caishen_coin();
			this.caishen_info.fill2c(ba);
		}
		this.left_item_num = ba.ReadInt();
		this.remain_cnt = ba.ReadInt();
	}
}