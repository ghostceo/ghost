using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_actor:GameNetInfo{
	//fields
	public int actor_type = 0;
	public int actor_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.actor_type = ba.ReadInt();
		this.actor_id = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.actor_type);
		ba.WriteInt(this.actor_id);
	}
}