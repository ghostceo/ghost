using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_letter_goods:GameNetInfo{
	//fields
	public int goods_id = 0;
	public int num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.goods_id = ba.ReadInt();
		this.num = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.goods_id);
		ba.WriteInt(this.num);
	}
}