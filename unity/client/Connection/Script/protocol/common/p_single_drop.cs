using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_single_drop:GameNetInfo{
	//fields
	public int type = 0;
	public int typeid = 0;
	public int weight = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.weight = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type);
		ba.WriteInt(this.typeid);
		ba.WriteInt(this.weight);
	}
}