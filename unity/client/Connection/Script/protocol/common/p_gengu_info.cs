using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_gengu_info:GameNetInfo{
	//fields
	public int level = 0;
	public int luck_point = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.level = ba.ReadInt();
		this.luck_point = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.level);
		ba.WriteInt(this.luck_point);
	}
}