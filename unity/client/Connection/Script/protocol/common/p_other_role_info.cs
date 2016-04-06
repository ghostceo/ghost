using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_other_role_info:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int sex = 0;
	public int faction_id = 0;
	public string family_name;
	public int category = 0;
	public int level = 0;
	public int level_rank = 0;
	public ArrayList equips;
	public int vip_level = 0;
	public int pk_points = 0;
	public string cur_title;
	public p_skin skin;
	public double fight_power = 0;
	public p_fst_attr base_fst_attr;
	public p_fst_attr fst_attr;
	public p_sec_attr sec_attr;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.sex = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.category = ba.ReadInt();
		this.level = ba.ReadInt();
		this.level_rank = ba.ReadInt();
		this.equips = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.equips.Add(p);
		}
		this.vip_level = ba.ReadInt();
		this.pk_points = ba.ReadInt();
		this.cur_title = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.skin = new p_skin();
			this.skin.fill2c(ba);
		}
		this.fight_power = ba.ReadDouble();
		if(ba.ReadByte() == 1){
			this.base_fst_attr = new p_fst_attr();
			this.base_fst_attr.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.fst_attr = new p_fst_attr();
			this.fst_attr.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.sec_attr = new p_sec_attr();
			this.sec_attr.fill2c(ba);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.faction_id);
		ba.WriteString(this.family_name);
		ba.WriteInt(this.category);
		ba.WriteInt(this.level);
		ba.WriteInt(this.level_rank);
		for (int i = 0; i < equips.Count; i++){
		((p_goods)this.equips[i]).fill2s(ba);		}
		ba.WriteInt(this.vip_level);
		ba.WriteInt(this.pk_points);
		ba.WriteString(this.cur_title);
		this.skin.fill2s(ba);
		ba.WriteDouble(this.fight_power);
		this.base_fst_attr.fill2s(ba);
		this.fst_attr.fill2s(ba);
		this.sec_attr.fill2s(ba);
	}
}