using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_activity_reward_info:GameNetInfo{
	//fields
	public int reward_type = 0;
	public ArrayList reward;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.reward_type = ba.ReadInt();
		this.reward = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.reward.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.reward_type);
		for (int i = 0; i < reward.Count; i++){
		((p_reward_prop)this.reward[i]).fill2s(ba);		}
	}
}