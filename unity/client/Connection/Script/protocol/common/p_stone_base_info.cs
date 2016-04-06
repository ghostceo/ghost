using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_stone_base_info:GameNetInfo{
	//fields
	public int typeid = 0;
	public string stonename;
	public int colour = 0;
	public int sell_type = 0;
	public int sell_price = 0;
	public int level = 0;
	public p_attr prop;
	public int init_exp = 0;
	public int next_level_exp = 0;
	public int next_typeid = 0;
	public int kind = 0;
	public int score = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.typeid = ba.ReadInt();
		this.stonename = ba.ReadString();
		this.colour = ba.ReadInt();
		this.sell_type = ba.ReadInt();
		this.sell_price = ba.ReadInt();
		this.level = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.prop = new p_attr();
			this.prop.fill2c(ba);
		}
		this.init_exp = ba.ReadInt();
		this.next_level_exp = ba.ReadInt();
		this.next_typeid = ba.ReadInt();
		this.kind = ba.ReadInt();
		this.score = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.typeid);
		ba.WriteString(this.stonename);
		ba.WriteInt(this.colour);
		ba.WriteInt(this.sell_type);
		ba.WriteInt(this.sell_price);
		ba.WriteInt(this.level);
		this.prop.fill2s(ba);
		ba.WriteInt(this.init_exp);
		ba.WriteInt(this.next_level_exp);
		ba.WriteInt(this.next_typeid);
		ba.WriteInt(this.kind);
		ba.WriteInt(this.score);
	}
}