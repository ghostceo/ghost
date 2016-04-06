using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_k_v:GameNetInfo{
	//fields
	public int key = 0;
	public int val = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.key = ba.ReadInt();
		this.val = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.key);
		ba.WriteInt(this.val);
	}
}