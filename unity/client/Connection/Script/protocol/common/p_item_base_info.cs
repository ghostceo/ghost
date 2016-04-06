using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_item_base_info:GameNetInfo{
	//fields
	public int typeid = 0;
	public string itemname;
	public int reincarnation = 0;
	public int kind = 0;
	public int colour = 0;
	public int usenum = 0;
	public int sell_type = 0;
	public int sell_price = 0;
	public p_use_requirement requirement;
	public ArrayList effects;
	public int cd_type = 0;
	public int cd_time = 0;
	public int is_overlap = 0;
	public int is_auto_use = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.typeid = ba.ReadInt();
		this.itemname = ba.ReadString();
		this.reincarnation = ba.ReadInt();
		this.kind = ba.ReadInt();
		this.colour = ba.ReadInt();
		this.usenum = ba.ReadInt();
		this.sell_type = ba.ReadInt();
		this.sell_price = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.requirement = new p_use_requirement();
			this.requirement.fill2c(ba);
		}
		this.effects = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_item_effect p = new p_item_effect();
			p.fill2c(ba);
			this.effects.Add(p);
		}
		this.cd_type = ba.ReadInt();
		this.cd_time = ba.ReadInt();
		this.is_overlap = ba.ReadInt();
		this.is_auto_use = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.typeid);
		ba.WriteString(this.itemname);
		ba.WriteInt(this.reincarnation);
		ba.WriteInt(this.kind);
		ba.WriteInt(this.colour);
		ba.WriteInt(this.usenum);
		ba.WriteInt(this.sell_type);
		ba.WriteInt(this.sell_price);
		this.requirement.fill2s(ba);
		for (int i = 0; i < effects.Count; i++){
		((p_item_effect)this.effects[i]).fill2s(ba);		}
		ba.WriteInt(this.cd_type);
		ba.WriteInt(this.cd_time);
		ba.WriteInt(this.is_overlap);
		ba.WriteInt(this.is_auto_use);
	}
}