using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_actor_buf:GameNetInfo{
	//fields
	public int buff_id = 0;
	public int remain_time = 0;
	public int actor_id = 0;
	public int actor_type = 0;
	public int from_actor_id = 0;
	public int from_actor_type = 0;
	public int start_time = 0;
	public int end_time = 0;
	public int buff_type = 0;
	public int value = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.buff_id = ba.ReadInt();
		this.remain_time = ba.ReadInt();
		this.actor_id = ba.ReadInt();
		this.actor_type = ba.ReadInt();
		this.from_actor_id = ba.ReadInt();
		this.from_actor_type = ba.ReadInt();
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.buff_type = ba.ReadInt();
		this.value = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.buff_id);
		ba.WriteInt(this.remain_time);
		ba.WriteInt(this.actor_id);
		ba.WriteInt(this.actor_type);
		ba.WriteInt(this.from_actor_id);
		ba.WriteInt(this.from_actor_type);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.buff_type);
		ba.WriteInt(this.value);
	}
}