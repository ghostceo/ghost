using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_activity_daily_info:GameNetInfo{
	//fields
	public int activity_id = 0;
	public int count = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.activity_id = ba.ReadInt();
		this.count = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.activity_id);
		ba.WriteInt(this.count);
	}
}