using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_mystery_shop_item:GameNetInfo{
	//fields
	public int goods_id = 0;
	public int typeid = 0;
	public int set_id = 0;
	public int org_price = 0;
	public int cur_price = 0;
	public int num = 0;
	public bool bind = false;
	public bool buy = false;
	public ArrayList p_goods_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.goods_id = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.set_id = ba.ReadInt();
		this.org_price = ba.ReadInt();
		this.cur_price = ba.ReadInt();
		this.num = ba.ReadInt();
		this.bind = ba.ReadBoolean();
		this.buy = ba.ReadBoolean();
		this.p_goods_info = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.p_goods_info.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.goods_id);
		ba.WriteInt(this.typeid);
		ba.WriteInt(this.set_id);
		ba.WriteInt(this.org_price);
		ba.WriteInt(this.cur_price);
		ba.WriteInt(this.num);
		ba.WriteBool(this.bind);
		ba.WriteBool(this.buy);
		for (int i = 0; i < p_goods_info.Count; i++){
		((p_goods)this.p_goods_info[i]).fill2s(ba);		}
	}
}