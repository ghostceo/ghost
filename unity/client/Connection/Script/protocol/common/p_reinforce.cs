using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_reinforce:GameNetInfo{
	//fields
	public int lv = 0;
	public int exp = 0;
	public int max_exp = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.lv = ba.ReadInt();
		this.exp = ba.ReadInt();
		this.max_exp = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.lv);
		ba.WriteInt(this.exp);
		ba.WriteInt(this.max_exp);
	}
}