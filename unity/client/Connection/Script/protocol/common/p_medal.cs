using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_medal:GameNetInfo{
	//fields
	public int medal_type = 0;
	public int medal_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.medal_type = ba.ReadInt();
		this.medal_id = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.medal_type);
		ba.WriteInt(this.medal_id);
	}
}