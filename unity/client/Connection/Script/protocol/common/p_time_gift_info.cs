using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_time_gift_info:GameNetInfo{
	//fields
	public int id = 0;
	public ArrayList goods_list;
	public int time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.goods_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.goods_list.Add(p);
		}
		this.time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		for (int i = 0; i < goods_list.Count; i++){
		((p_goods)this.goods_list[i]).fill2s(ba);		}
		ba.WriteInt(this.time);
	}
}