using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_stat_toc:IncommingBase{
	//ID
	public int protocolID = 2305;

	//fields
	public int barrier_id = 0;
	public int succ_rate = 0;
	public int total_time = 0;
	public int fight_num = 0;
	public int all_exp = 0;
	public int all_silver = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.barrier_id = ba.ReadInt();
		this.succ_rate = ba.ReadInt();
		this.total_time = ba.ReadInt();
		this.fight_num = ba.ReadInt();
		this.all_exp = ba.ReadInt();
		this.all_silver = ba.ReadInt();
	}
}