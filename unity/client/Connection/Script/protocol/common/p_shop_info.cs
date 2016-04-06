using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_shop_info:GameNetInfo{
	//fields
	public int id = 0;
	public string name;
	public ArrayList branch_shop;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.name = ba.ReadString();
		this.branch_shop = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_shop_info p = new p_shop_info();
			p.fill2c(ba);
			this.branch_shop.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteString(this.name);
		for (int i = 0; i < branch_shop.Count; i++){
		((p_shop_info)this.branch_shop[i]).fill2s(ba);		}
	}
}