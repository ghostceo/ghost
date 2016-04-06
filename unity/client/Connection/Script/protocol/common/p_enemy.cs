using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_enemy:GameNetInfo{
	//fields
	public int actor_key = 0;
	public int total_hurt = 0;
	public int last_att_time = 0;
	public p_pos pos;
	public int state = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.actor_key = ba.ReadInt();
		this.total_hurt = ba.ReadInt();
		this.last_att_time = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.state = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.actor_key);
		ba.WriteInt(this.total_hurt);
		ba.WriteInt(this.last_att_time);
		this.pos.fill2s(ba);
		ba.WriteInt(this.state);
	}
}