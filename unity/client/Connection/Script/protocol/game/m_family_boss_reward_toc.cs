using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_boss_reward_toc:IncommingBase{
	//ID
	public int protocolID = 3186;

	//fields
	public p_family_boss_reward reward;
	public bool is_kill = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.reward = new p_family_boss_reward();
			this.reward.fill2c(ba);
		}
		this.is_kill = ba.ReadBoolean();
	}
}