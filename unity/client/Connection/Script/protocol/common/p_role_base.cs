using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_base:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public string account_name;
	public int sex = 0;
	public int create_time = 0;
	public int status = 0;
	public int head = 0;
	public int faction_id = 0;
	public int team_id = 0;
	public int family_id = 0;
	public string family_name;
	public string cur_title;
	public string cur_title_color;
	public int pk_mode = 0;
	public int pk_points = 0;
	public int weapon_type = 0;
	public ArrayList buffs;
	public int platform_id = 0;
	public int server_id = 0;
	public bool is_disabled = false;
	public int move_speed = 0;
	public int attack_speed = 0;
	public int category = 0;
	public p_fst_attr base_fst_attr;
	public p_fst_attr fst_attr;
	public p_sec_attr sec_attr;
	public double fight_power = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.account_name = ba.ReadString();
		this.sex = ba.ReadInt();
		this.create_time = ba.ReadInt();
		this.status = ba.ReadInt();
		this.head = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.team_id = ba.ReadInt();
		this.family_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.cur_title = ba.ReadString();
		this.cur_title_color = ba.ReadString();
		this.pk_mode = ba.ReadInt();
		this.pk_points = ba.ReadInt();
		this.weapon_type = ba.ReadInt();
		this.buffs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_actor_buf p = new p_actor_buf();
			p.fill2c(ba);
			this.buffs.Add(p);
		}
		this.platform_id = ba.ReadInt();
		this.server_id = ba.ReadInt();
		this.is_disabled = ba.ReadBoolean();
		this.move_speed = ba.ReadInt();
		this.attack_speed = ba.ReadInt();
		this.category = ba.ReadInt();
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
		this.fight_power = ba.ReadDouble();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteString(this.account_name);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.create_time);
		ba.WriteInt(this.status);
		ba.WriteInt(this.head);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.team_id);
		ba.WriteInt(this.family_id);
		ba.WriteString(this.family_name);
		ba.WriteString(this.cur_title);
		ba.WriteString(this.cur_title_color);
		ba.WriteInt(this.pk_mode);
		ba.WriteInt(this.pk_points);
		ba.WriteInt(this.weapon_type);
		for (int i = 0; i < buffs.Count; i++){
		((p_actor_buf)this.buffs[i]).fill2s(ba);		}
		ba.WriteInt(this.platform_id);
		ba.WriteInt(this.server_id);
		ba.WriteBool(this.is_disabled);
		ba.WriteInt(this.move_speed);
		ba.WriteInt(this.attack_speed);
		ba.WriteInt(this.category);
		this.base_fst_attr.fill2s(ba);
		this.fst_attr.fill2s(ba);
		this.sec_attr.fill2s(ba);
		ba.WriteDouble(this.fight_power);
	}
}