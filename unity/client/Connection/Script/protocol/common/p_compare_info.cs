using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_compare_info:GameNetInfo{
	//fields
	public int id = 0;
	public int goods_id1 = 0;
	public int goods_id2 = 0;
	public int price1 = 0;
	public int price2 = 0;
	public bool state = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.goods_id1 = ba.ReadInt();
		this.goods_id2 = ba.ReadInt();
		this.price1 = ba.ReadInt();
		this.price2 = ba.ReadInt();
		this.state = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.goods_id1);
		ba.WriteInt(this.goods_id2);
		ba.WriteInt(this.price1);
		ba.WriteInt(this.price2);
		ba.WriteBool(this.state);
	}
}