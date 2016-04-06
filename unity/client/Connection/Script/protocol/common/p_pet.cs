using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_pet:GameNetInfo{
	//fields
	public int pet_id = 0;
	public int type_id = 0;
	public int category = 0;
	public int role_id = 0;
	public string role_name;
	public int attack_speed = 0;
	public int attack_type = 0;
	public string pet_name;
	public int color = 0;
	public int star_lv = 0;
	public int quality = 0;
	public ArrayList buffs;
	public ArrayList equips;
	public int hp = 0;
	public int pk_mode = 0;
	public p_fst_attr fst_attr;
	public p_sec_attr sec_attr;
	public double fight_power = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.type_id = ba.ReadInt();
		this.category = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.attack_speed = ba.ReadInt();
		this.attack_type = ba.ReadInt();
		this.pet_name = ba.ReadString();
		this.color = ba.ReadInt();
		this.star_lv = ba.ReadInt();
		this.quality = ba.ReadInt();
		this.buffs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_actor_buf p = new p_actor_buf();
			p.fill2c(ba);
			this.buffs.Add(p);
		}
		this.equips = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.equips.Add(p);
		}
		this.hp = ba.ReadInt();
		this.pk_mode = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.fst_attr = new p_fst_attr();
			this.fst_attr.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.sec_attr = new p_sec_attr();
			this.sec_attr.fill2c(ba);
		}
		this.fight_power = ba.ReadDouble();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.pet_id);
		ba.WriteInt(this.type_id);
		ba.WriteInt(this.category);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.attack_speed);
		ba.WriteInt(this.attack_type);
		ba.WriteString(this.pet_name);
		ba.WriteInt(this.color);
		ba.WriteInt(this.star_lv);
		ba.WriteInt(this.quality);
		for (int i = 0; i < buffs.Count; i++){
		((p_actor_buf)this.buffs[i]).fill2s(ba);		}
		for (int i = 0; i < equips.Count; i++){
		((p_goods)this.equips[i]).fill2s(ba);		}
		ba.WriteInt(this.hp);
		ba.WriteInt(this.pk_mode);
		this.fst_attr.fill2s(ba);
		this.sec_attr.fill2s(ba);
		ba.WriteDouble(this.fight_power);
	}
}