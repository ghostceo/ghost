using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_reward_info_toc:IncommingBase{
	//ID
	public int protocolID = 7410;

	//fields
	public bool succ = true;
	public int reason_code = 0;
	public bool can_fetch_daily = false;
	public bool can_fetch_weekly = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason_code = ba.ReadInt();
		this.can_fetch_daily = ba.ReadBoolean();
		this.can_fetch_weekly = ba.ReadBoolean();
	}
}