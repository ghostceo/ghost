using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_bag_content:GameNetInfo{
	//fields
	public int bag_id = 0;
	public ArrayList goods;
	public int rows = 0;
	public int columns = 0;
	public int typeid = 0;
	public int grid_number = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.bag_id = ba.ReadInt();
		this.goods = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.goods.Add(p);
		}
		this.rows = ba.ReadInt();
		this.columns = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.grid_number = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.bag_id);
		for (int i = 0; i < goods.Count; i++){
		((p_goods)this.goods[i]).fill2s(ba);		}
		ba.WriteInt(this.rows);
		ba.WriteInt(this.columns);
		ba.WriteInt(this.typeid);
		ba.WriteInt(this.grid_number);
	}
}