using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_login_reward_info_toc:IncommingBase{
	//ID
	public int protocolID = 19100;

	//fields
	public bool can_fetch = false;
	public int cur_day = 0;
	public ArrayList fetched_day;
	public ArrayList rewards;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.can_fetch = ba.ReadBoolean();
		this.cur_day = ba.ReadInt();
		this.fetched_day = new ArrayList();
		ba.ReadIntArray(this.fetched_day);
		this.rewards = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.rewards.Add(p);
		}
	}
}