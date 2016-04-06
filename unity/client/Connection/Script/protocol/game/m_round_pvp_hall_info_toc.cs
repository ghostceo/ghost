using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_round_pvp_hall_info_toc:IncommingBase{
	//ID
	public int protocolID = 10806;

	//fields
	public int next_round_time = 0;
	public int cur_round = 0;
	public bool is_this_round_finished = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.next_round_time = ba.ReadInt();
		this.cur_round = ba.ReadInt();
		this.is_this_round_finished = ba.ReadBoolean();
	}
}