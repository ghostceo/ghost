using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_shop_goods_info:GameNetInfo{
	//fields
	public int goods_id = 0;
	public int type = 0;
	public int seat_id = 0;
	public p_shop_price price;
	public p_attr property;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.goods_id = ba.ReadInt();
		this.type = ba.ReadInt();
		this.seat_id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.price = new p_shop_price();
			this.price.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.property = new p_attr();
			this.property.fill2c(ba);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.goods_id);
		ba.WriteInt(this.type);
		ba.WriteInt(this.seat_id);
		this.price.fill2s(ba);
		this.property.fill2s(ba);
	}
}