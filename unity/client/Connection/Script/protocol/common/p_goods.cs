using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_goods:GameNetInfo{
	//fields
	public int id = 0;
	public int type = 0;
	public int roleid = 0;
	public string owner_name;
	public int bagposition = 0;
	public int current_num = 0;
	public int bagid = 0;
	public int typeid = 0;
	public bool bind = false;
	public int start_time = 0;
	public int end_time = 0;
	public int colour = 0;
	public string name;
	public int level = 0;
	public int loadposition = 0;
	public p_reinforce reinforce_data;
	public int punch_num = 0;
	public p_attr main_property;
	public ArrayList init_addition_property;
	public ArrayList addition_property;
	public ArrayList super_property;
	public p_super_equip s_equip_data;
	public ArrayList stones;
	public ArrayList super_suit;
	public int exp = 0;
	public int stone_suit_level = 0;
	public int pet_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.type = ba.ReadInt();
		this.roleid = ba.ReadInt();
		this.owner_name = ba.ReadString();
		this.bagposition = ba.ReadInt();
		this.current_num = ba.ReadInt();
		this.bagid = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.bind = ba.ReadBoolean();
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.colour = ba.ReadInt();
		this.name = ba.ReadString();
		this.level = ba.ReadInt();
		this.loadposition = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.reinforce_data = new p_reinforce();
			this.reinforce_data.fill2c(ba);
		}
		this.punch_num = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.main_property = new p_attr();
			this.main_property.fill2c(ba);
		}
		this.init_addition_property = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_attr p = new p_attr();
			p.fill2c(ba);
			this.init_addition_property.Add(p);
		}
		this.addition_property = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_attr p = new p_attr();
			p.fill2c(ba);
			this.addition_property.Add(p);
		}
		this.super_property = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_attr p = new p_attr();
			p.fill2c(ba);
			this.super_property.Add(p);
		}
		if(ba.ReadByte() == 1){
			this.s_equip_data = new p_super_equip();
			this.s_equip_data.fill2c(ba);
		}
		this.stones = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.stones.Add(p);
		}
		this.super_suit = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_super_suit p = new p_super_suit();
			p.fill2c(ba);
			this.super_suit.Add(p);
		}
		this.exp = ba.ReadInt();
		this.stone_suit_level = ba.ReadInt();
		this.pet_id = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.type);
		ba.WriteInt(this.roleid);
		ba.WriteString(this.owner_name);
		ba.WriteInt(this.bagposition);
		ba.WriteInt(this.current_num);
		ba.WriteInt(this.bagid);
		ba.WriteInt(this.typeid);
		ba.WriteBool(this.bind);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.colour);
		ba.WriteString(this.name);
		ba.WriteInt(this.level);
		ba.WriteInt(this.loadposition);
		this.reinforce_data.fill2s(ba);
		ba.WriteInt(this.punch_num);
		this.main_property.fill2s(ba);
		for (int i = 0; i < init_addition_property.Count; i++){
		((p_attr)this.init_addition_property[i]).fill2s(ba);		}
		for (int i = 0; i < addition_property.Count; i++){
		((p_attr)this.addition_property[i]).fill2s(ba);		}
		for (int i = 0; i < super_property.Count; i++){
		((p_attr)this.super_property[i]).fill2s(ba);		}
		this.s_equip_data.fill2s(ba);
		for (int i = 0; i < stones.Count; i++){
		((p_goods)this.stones[i]).fill2s(ba);		}
		for (int i = 0; i < super_suit.Count; i++){
		((p_super_suit)this.super_suit[i]).fill2s(ba);		}
		ba.WriteInt(this.exp);
		ba.WriteInt(this.stone_suit_level);
		ba.WriteInt(this.pet_id);
	}
}