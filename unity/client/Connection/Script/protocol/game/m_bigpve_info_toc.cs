using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bigpve_info_toc:IncommingBase{
	//ID
	public int protocolID = 10603;

	//fields
	public int fb_start_time = 0;
	public int fb_end_time = 0;
	public int next_silver_buff_id = 0;
	public int need_cost_silver = 0;
	public int next_gold_buff_id = 0;
	public int need_cost_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.fb_start_time = ba.ReadInt();
		this.fb_end_time = ba.ReadInt();
		this.next_silver_buff_id = ba.ReadInt();
		this.need_cost_silver = ba.ReadInt();
		this.next_gold_buff_id = ba.ReadInt();
		this.need_cost_gold = ba.ReadInt();
	}
}