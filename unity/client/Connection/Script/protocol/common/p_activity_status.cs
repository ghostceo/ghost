using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_activity_status:GameNetInfo{
	//fields
	public int id = 0;
	public int status = 0;
	public int left_times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.status = ba.ReadInt();
		this.left_times = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.status);
		ba.WriteInt(this.left_times);
	}
}