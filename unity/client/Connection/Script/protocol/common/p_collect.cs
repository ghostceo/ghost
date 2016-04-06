using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_collect:GameNetInfo{
	//fields
	public int rate = 0;
	public int typeid = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rate = ba.ReadInt();
		this.typeid = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rate);
		ba.WriteInt(this.typeid);
	}
}