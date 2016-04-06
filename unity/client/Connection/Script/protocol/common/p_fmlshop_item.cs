using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_fmlshop_item:GameNetInfo{
	//fields
	public int item_id = 0;
	public int level_limit = 0;
	public int buy_price = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.item_id = ba.ReadInt();
		this.level_limit = ba.ReadInt();
		this.buy_price = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.item_id);
		ba.WriteInt(this.level_limit);
		ba.WriteInt(this.buy_price);
	}
}