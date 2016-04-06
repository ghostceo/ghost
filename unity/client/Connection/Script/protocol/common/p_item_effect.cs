using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_item_effect:GameNetInfo{
	//fields
	public int funid = 0;
	public string parameter;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.funid = ba.ReadInt();
		this.parameter = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.funid);
		ba.WriteString(this.parameter);
	}
}