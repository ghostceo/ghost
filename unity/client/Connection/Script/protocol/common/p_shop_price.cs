using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_shop_price:GameNetInfo{
	//fields
	public int currency_type = 0;
	public int price = 0;
	public int hot_price = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.currency_type = ba.ReadInt();
		this.price = ba.ReadInt();
		this.hot_price = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.currency_type);
		ba.WriteInt(this.price);
		ba.WriteInt(this.hot_price);
	}
}