using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rankreward_info_toc:IncommingBase{
	//ID
	public int protocolID = 9001;

	//fields
	public int rank_id = 0;
	public bool show_data = true;
	public bool can_fetch = false;
	public p_jingjie_rank_yesterday last_rank;
	public int reward_silver = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank_id = ba.ReadInt();
		this.show_data = ba.ReadBoolean();
		this.can_fetch = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.last_rank = new p_jingjie_rank_yesterday();
			this.last_rank.fill2c(ba);
		}
		this.reward_silver = ba.ReadInt();
	}
}