using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_reward_daily_info:GameNetInfo{
	//fields
	public int id = 0;
	public bool can_reward = false;
	public int timer = 0;
	public int exp = 0;
	public int remain_count = 0;
	public int gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.can_reward = ba.ReadBoolean();
		this.timer = ba.ReadInt();
		this.exp = ba.ReadInt();
		this.remain_count = ba.ReadInt();
		this.gold = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteBool(this.can_reward);
		ba.WriteInt(this.timer);
		ba.WriteInt(this.exp);
		ba.WriteInt(this.remain_count);
		ba.WriteInt(this.gold);
	}
}