using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_attr:GameNetInfo{
	//fields
	public int attr_code = 0;
	public int min_value = 0;
	public int max_value = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.attr_code = ba.ReadInt();
		this.min_value = ba.ReadInt();
		this.max_value = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.attr_code);
		ba.WriteInt(this.min_value);
		ba.WriteInt(this.max_value);
	}
}