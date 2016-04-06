using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_xfire_param:GameNetInfo{
	//fields
	public int xfire_type = 0;
	public int goods_id = 0;
	public int goods_type = 0;
	public int goods_type_id = 0;
	public int goods_number = 0;
	public int xfire_place = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.xfire_type = ba.ReadInt();
		this.goods_id = ba.ReadInt();
		this.goods_type = ba.ReadInt();
		this.goods_type_id = ba.ReadInt();
		this.goods_number = ba.ReadInt();
		this.xfire_place = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.xfire_type);
		ba.WriteInt(this.goods_id);
		ba.WriteInt(this.goods_type);
		ba.WriteInt(this.goods_type_id);
		ba.WriteInt(this.goods_number);
		ba.WriteInt(this.xfire_place);
	}
}