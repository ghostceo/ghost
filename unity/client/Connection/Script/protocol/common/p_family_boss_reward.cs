using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_boss_reward:GameNetInfo{
	//fields
	public double exp = 0;
	public double silver = 0;
	public int active_points = 0;
	public int family_contribute = 0;
	public p_reward_prop reward_prop;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.exp = ba.ReadDouble();
		this.silver = ba.ReadDouble();
		this.active_points = ba.ReadInt();
		this.family_contribute = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.reward_prop = new p_reward_prop();
			this.reward_prop.fill2c(ba);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteDouble(this.exp);
		ba.WriteDouble(this.silver);
		ba.WriteInt(this.active_points);
		ba.WriteInt(this.family_contribute);
		this.reward_prop.fill2s(ba);
	}
}