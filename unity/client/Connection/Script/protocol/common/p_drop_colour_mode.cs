using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_drop_colour_mode:GameNetInfo{
	//fields
	public int colour = 0;
	public int rate = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.colour = ba.ReadInt();
		this.rate = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.colour);
		ba.WriteInt(this.rate);
	}
}