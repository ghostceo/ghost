using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_caishen_firecoin_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 10004;

	//fields
	public int times = 0;
	public int cost_gold = 0;
	public int get_coin = 0;
	public int cost_item_num = 0;
	public p_caishen_coin caishen_info;
	public int left_item_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.times = ba.ReadInt();
		this.cost_gold = ba.ReadInt();
		this.get_coin = ba.ReadInt();
		this.cost_item_num = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.caishen_info = new p_caishen_coin();
			this.caishen_info.fill2c(ba);
		}
		this.left_item_num = ba.ReadInt();
	}
}