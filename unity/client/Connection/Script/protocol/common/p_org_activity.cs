using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_org_activity:GameNetInfo{
	//fields
	public int activity_id = 0;
	public int max_amount = 0;
	public int cur_amount = 0;
	public int left_reward_count = 0;
	public int left_days = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.activity_id = ba.ReadInt();
		this.max_amount = ba.ReadInt();
		this.cur_amount = ba.ReadInt();
		this.left_reward_count = ba.ReadInt();
		this.left_days = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.activity_id);
		ba.WriteInt(this.max_amount);
		ba.WriteInt(this.cur_amount);
		ba.WriteInt(this.left_reward_count);
		ba.WriteInt(this.left_days);
	}
}