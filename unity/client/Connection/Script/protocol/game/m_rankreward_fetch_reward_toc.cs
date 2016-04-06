using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rankreward_fetch_reward_toc:IncommingBase{
	//ID
	public int protocolID = 9003;

	//fields
	public int rank_id = 0;
	public int error_code = 0;
	public string reason;
	public int reward_silver = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank_id = ba.ReadInt();
		this.error_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.reward_silver = ba.ReadInt();
	}
}