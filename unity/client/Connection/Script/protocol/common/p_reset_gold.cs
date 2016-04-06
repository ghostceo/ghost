using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_reset_gold:GameNetInfo{
	//fields
	public int chapter_id = 0;
	public int gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.chapter_id = ba.ReadInt();
		this.gold = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.chapter_id);
		ba.WriteInt(this.gold);
	}
}