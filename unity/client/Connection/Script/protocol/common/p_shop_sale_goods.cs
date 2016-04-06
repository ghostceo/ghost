using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_shop_sale_goods:GameNetInfo{
	//fields
	public int id = 0;
	public int type_id = 0;
	public int position = 0;
	public int number = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.type_id = ba.ReadInt();
		this.position = ba.ReadInt();
		this.number = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.type_id);
		ba.WriteInt(this.position);
		ba.WriteInt(this.number);
	}
}