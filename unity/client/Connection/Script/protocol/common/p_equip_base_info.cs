using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_equip_base_info:GameNetInfo{
	//fields
	public int typeid = 0;
	public string equipname;
	public int slot_num = 0;
	public int kind = 0;
	public int colour = 0;
	public int endurance = 0;
	public p_use_requirement requirement;
	public int sell_type = 0;
	public int sell_price = 0;
	public int grade_lv = 0;
	public p_attr main_property;
	public int suit_index = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.typeid = ba.ReadInt();
		this.equipname = ba.ReadString();
		this.slot_num = ba.ReadInt();
		this.kind = ba.ReadInt();
		this.colour = ba.ReadInt();
		this.endurance = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.requirement = new p_use_requirement();
			this.requirement.fill2c(ba);
		}
		this.sell_type = ba.ReadInt();
		this.sell_price = ba.ReadInt();
		this.grade_lv = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.main_property = new p_attr();
			this.main_property.fill2c(ba);
		}
		this.suit_index = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.typeid);
		ba.WriteString(this.equipname);
		ba.WriteInt(this.slot_num);
		ba.WriteInt(this.kind);
		ba.WriteInt(this.colour);
		ba.WriteInt(this.endurance);
		this.requirement.fill2s(ba);
		ba.WriteInt(this.sell_type);
		ba.WriteInt(this.sell_price);
		ba.WriteInt(this.grade_lv);
		this.main_property.fill2s(ba);
		ba.WriteInt(this.suit_index);
	}
}