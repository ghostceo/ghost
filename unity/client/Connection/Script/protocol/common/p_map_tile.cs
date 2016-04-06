using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_tile:GameNetInfo{
	//fields
	public int tx = 0;
	public int ty = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.tx = ba.ReadInt();
		this.ty = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.tx);
		ba.WriteInt(this.ty);
	}
}