using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_idol_pray_toc:IncommingBase{
	//ID
	public int protocolID = 11703;

	//fields
	public int type = 0;
	public int cur_times = 0;
	public int max_times = 0;
	public int add_family_contribution = 0;
	public int add_family_active_points = 0;
	public int add_silver = 0;
	public int type_id = 0;
	public int cost_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.cur_times = ba.ReadInt();
		this.max_times = ba.ReadInt();
		this.add_family_contribution = ba.ReadInt();
		this.add_family_active_points = ba.ReadInt();
		this.add_silver = ba.ReadInt();
		this.type_id = ba.ReadInt();
		this.cost_gold = ba.ReadInt();
	}
}