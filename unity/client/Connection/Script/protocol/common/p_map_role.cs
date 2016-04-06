using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_role:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int faction_id = 0;
	public string cur_title;
	public int family_id = 0;
	public string family_name;
	public p_pos pos;
	public p_walk_path last_walk_path;
	public p_pos last_key_path;
	public int hp = 0;
	public int max_hp = 0;
	public int mp = 0;
	public int max_mp = 0;
	public p_skin skin;
	public int move_speed = 0;
	public int team_id = 0;
	public int level = 0;
	public int pk_point = 0;
	public int state = 0;
	public bool gray_name = false;
	public ArrayList state_buffs;
	public string cur_title_color;
	public int equip_ring_color = 0;
	public bool show_equip_ring = true;
	public int vip_level = 0;
	public int mount_color = 0;
	public int xfire_level = 0;
	public int sex = 0;
	public int category = 0;
	public int jingjie = 0;
	public double fight_power = 0;
	public bool is_mirror = false;
	public int medicine = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.faction_id = ba.ReadInt();
		this.cur_title = ba.ReadString();
		this.family_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.last_walk_path = new p_walk_path();
			this.last_walk_path.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.last_key_path = new p_pos();
			this.last_key_path.fill2c(ba);
		}
		this.hp = ba.ReadInt();
		this.max_hp = ba.ReadInt();
		this.mp = ba.ReadInt();
		this.max_mp = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.skin = new p_skin();
			this.skin.fill2c(ba);
		}
		this.move_speed = ba.ReadInt();
		this.team_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.pk_point = ba.ReadInt();
		this.state = ba.ReadInt();
		this.gray_name = ba.ReadBoolean();
		this.state_buffs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_actor_buf p = new p_actor_buf();
			p.fill2c(ba);
			this.state_buffs.Add(p);
		}
		this.cur_title_color = ba.ReadString();
		this.equip_ring_color = ba.ReadInt();
		this.show_equip_ring = ba.ReadBoolean();
		this.vip_level = ba.ReadInt();
		this.mount_color = ba.ReadInt();
		this.xfire_level = ba.ReadInt();
		this.sex = ba.ReadInt();
		this.category = ba.ReadInt();
		this.jingjie = ba.ReadInt();
		this.fight_power = ba.ReadDouble();
		this.is_mirror = ba.ReadBoolean();
		this.medicine = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.faction_id);
		ba.WriteString(this.cur_title);
		ba.WriteInt(this.family_id);
		ba.WriteString(this.family_name);
		this.pos.fill2s(ba);
		this.last_walk_path.fill2s(ba);
		this.last_key_path.fill2s(ba);
		ba.WriteInt(this.hp);
		ba.WriteInt(this.max_hp);
		ba.WriteInt(this.mp);
		ba.WriteInt(this.max_mp);
		this.skin.fill2s(ba);
		ba.WriteInt(this.move_speed);
		ba.WriteInt(this.team_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.pk_point);
		ba.WriteInt(this.state);
		ba.WriteBool(this.gray_name);
		for (int i = 0; i < state_buffs.Count; i++){
		((p_actor_buf)this.state_buffs[i]).fill2s(ba);		}
		ba.WriteString(this.cur_title_color);
		ba.WriteInt(this.equip_ring_color);
		ba.WriteBool(this.show_equip_ring);
		ba.WriteInt(this.vip_level);
		ba.WriteInt(this.mount_color);
		ba.WriteInt(this.xfire_level);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.category);
		ba.WriteInt(this.jingjie);
		ba.WriteDouble(this.fight_power);
		ba.WriteBool(this.is_mirror);
		ba.WriteInt(this.medicine);
	}
}