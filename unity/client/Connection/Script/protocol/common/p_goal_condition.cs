using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_goal_condition:GameNetInfo{
	//fields
	public int condition_id = 0;
	public int status = 0;
	public int item_id = 0;
	public int limit = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.condition_id = ba.ReadInt();
		this.status = ba.ReadInt();
		this.item_id = ba.ReadInt();
		this.limit = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.condition_id);
		ba.WriteInt(this.status);
		ba.WriteInt(this.item_id);
		ba.WriteInt(this.limit);
	}
}