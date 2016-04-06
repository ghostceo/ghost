using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_hanging_buff:GameNetInfo{
	//fields
	public int start_time = 0;
	public int end_time = 0;
	public int type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.type = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.type);
	}
}