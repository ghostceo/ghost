using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_drop_quality_mode:GameNetInfo{
	//fields
	public int quality = 0;
	public int rate = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.quality = ba.ReadInt();
		this.rate = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.quality);
		ba.WriteInt(this.rate);
	}
}