using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_server_npc_base_info:GameNetInfo{
	//fields
	public int type_id = 0;
	public string npc_name;
	public int npc_country = 0;
	public int npc_type = 0;
	public int npc_kind_id = 0;
	public int level = 0;
	public int max_hp = 0;
	public int max_mp = 0;
	public int min_attack = 0;
	public int max_attack = 0;
	public int phy_defence = 0;
	public int magic_defence = 0;
	public int blood_resume_speed = 0;
	public int magic_resume_speed = 0;
	public int double_attack = 0;
	public int lucky = 0;
	public int move_speed = 0;
	public int attack_speed = 0;
	public int miss = 0;
	public int no_defence = 0;
	public int phy_anti = 0;
	public int magic_anti = 0;
	public int poisoning_resist = 0;
	public int dizzy_resist = 0;
	public int freeze_resist = 0;
	public int equip_score = 0;
	public int spec_score_one = 0;
	public int spec_score_two = 0;
	public int hit_rate = 0;
	public int attack_type = 0;
	public bool is_undead = false;
	public int guard_radius = 0;
	public int attention_radius = 0;
	public int activity_radius = 0;
	public p_refresh_info refresh;
	public ArrayList skills;
	public int gongxun = 0;
	public int block = 0;
	public int wreck = 0;
	public int tough = 0;
	public int vigour = 0;
	public int week = 0;
	public int molder = 0;
	public int hunger = 0;
	public int bless = 0;
	public int crit = 0;
	public int counter = 0;
	public int combos = 0;
	public int bloodline = 0;
	public int hurt_rate = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type_id = ba.ReadInt();
		this.npc_name = ba.ReadString();
		this.npc_country = ba.ReadInt();
		this.npc_type = ba.ReadInt();
		this.npc_kind_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.max_hp = ba.ReadInt();
		this.max_mp = ba.ReadInt();
		this.min_attack = ba.ReadInt();
		this.max_attack = ba.ReadInt();
		this.phy_defence = ba.ReadInt();
		this.magic_defence = ba.ReadInt();
		this.blood_resume_speed = ba.ReadInt();
		this.magic_resume_speed = ba.ReadInt();
		this.double_attack = ba.ReadInt();
		this.lucky = ba.ReadInt();
		this.move_speed = ba.ReadInt();
		this.attack_speed = ba.ReadInt();
		this.miss = ba.ReadInt();
		this.no_defence = ba.ReadInt();
		this.phy_anti = ba.ReadInt();
		this.magic_anti = ba.ReadInt();
		this.poisoning_resist = ba.ReadInt();
		this.dizzy_resist = ba.ReadInt();
		this.freeze_resist = ba.ReadInt();
		this.equip_score = ba.ReadInt();
		this.spec_score_one = ba.ReadInt();
		this.spec_score_two = ba.ReadInt();
		this.hit_rate = ba.ReadInt();
		this.attack_type = ba.ReadInt();
		this.is_undead = ba.ReadBoolean();
		this.guard_radius = ba.ReadInt();
		this.attention_radius = ba.ReadInt();
		this.activity_radius = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.refresh = new p_refresh_info();
			this.refresh.fill2c(ba);
		}
		this.skills = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_monster_skill p = new p_monster_skill();
			p.fill2c(ba);
			this.skills.Add(p);
		}
		this.gongxun = ba.ReadInt();
		this.block = ba.ReadInt();
		this.wreck = ba.ReadInt();
		this.tough = ba.ReadInt();
		this.vigour = ba.ReadInt();
		this.week = ba.ReadInt();
		this.molder = ba.ReadInt();
		this.hunger = ba.ReadInt();
		this.bless = ba.ReadInt();
		this.crit = ba.ReadInt();
		this.counter = ba.ReadInt();
		this.combos = ba.ReadInt();
		this.bloodline = ba.ReadInt();
		this.hurt_rate = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type_id);
		ba.WriteString(this.npc_name);
		ba.WriteInt(this.npc_country);
		ba.WriteInt(this.npc_type);
		ba.WriteInt(this.npc_kind_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.max_hp);
		ba.WriteInt(this.max_mp);
		ba.WriteInt(this.min_attack);
		ba.WriteInt(this.max_attack);
		ba.WriteInt(this.phy_defence);
		ba.WriteInt(this.magic_defence);
		ba.WriteInt(this.blood_resume_speed);
		ba.WriteInt(this.magic_resume_speed);
		ba.WriteInt(this.double_attack);
		ba.WriteInt(this.lucky);
		ba.WriteInt(this.move_speed);
		ba.WriteInt(this.attack_speed);
		ba.WriteInt(this.miss);
		ba.WriteInt(this.no_defence);
		ba.WriteInt(this.phy_anti);
		ba.WriteInt(this.magic_anti);
		ba.WriteInt(this.poisoning_resist);
		ba.WriteInt(this.dizzy_resist);
		ba.WriteInt(this.freeze_resist);
		ba.WriteInt(this.equip_score);
		ba.WriteInt(this.spec_score_one);
		ba.WriteInt(this.spec_score_two);
		ba.WriteInt(this.hit_rate);
		ba.WriteInt(this.attack_type);
		ba.WriteBool(this.is_undead);
		ba.WriteInt(this.guard_radius);
		ba.WriteInt(this.attention_radius);
		ba.WriteInt(this.activity_radius);
		this.refresh.fill2s(ba);
		for (int i = 0; i < skills.Count; i++){
		((p_monster_skill)this.skills[i]).fill2s(ba);		}
		ba.WriteInt(this.gongxun);
		ba.WriteInt(this.block);
		ba.WriteInt(this.wreck);
		ba.WriteInt(this.tough);
		ba.WriteInt(this.vigour);
		ba.WriteInt(this.week);
		ba.WriteInt(this.molder);
		ba.WriteInt(this.hunger);
		ba.WriteInt(this.bless);
		ba.WriteInt(this.crit);
		ba.WriteInt(this.counter);
		ba.WriteInt(this.combos);
		ba.WriteInt(this.bloodline);
		ba.WriteInt(this.hurt_rate);
	}
}