using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_boss_call:GameNetInfo{
	//fields
	public string boss_name;
	public int type = 0;
	public int call_gold = 0;
	public int remain_call_num = 0;
	public p_family_boss_reward call_reward;
	public p_family_boss_reward joinin_reward;
	public p_family_boss_reward killer_reward;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.boss_name = ba.ReadString();
		this.type = ba.ReadInt();
		this.call_gold = ba.ReadInt();
		this.remain_call_num = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.call_reward = new p_family_boss_reward();
			this.call_reward.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.joinin_reward = new p_family_boss_reward();
			this.joinin_reward.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.killer_reward = new p_family_boss_reward();
			this.killer_reward.fill2c(ba);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteString(this.boss_name);
		ba.WriteInt(this.type);
		ba.WriteInt(this.call_gold);
		ba.WriteInt(this.remain_call_num);
		this.call_reward.fill2s(ba);
		this.joinin_reward.fill2s(ba);
		this.killer_reward.fill2s(ba);
	}
}