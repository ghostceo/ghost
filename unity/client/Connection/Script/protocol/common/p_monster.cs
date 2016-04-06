using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_monster:GameNetInfo{
	//fields
	public int monsterid = 0;
	public int typeid = 0;
	public int state = 0;
	public int mapid = 0;
	public int hp = 0;
	public int mp;
	public p_pos pos;
	public p_pos reborn_pos;
	public ArrayList first_enemies;
	public ArrayList second_enemies;
	public ArrayList third_enemies;
	public int max_mp = 0;
	public int max_hp = 0;
	public ArrayList buffs;
	public string monstername;
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
	public int min_attack = 0;
	public int max_attack = 0;
	public int phy_anti = 0;
	public int magic_anti = 0;
	public int poisoning_resist = 0;
	public int dizzy_resist = 0;
	public int freeze_resist = 0;
	public int equip_score = 0;
	public int spec_score_one = 0;
	public int spec_score_two = 0;
	public int hit_rate = 0;
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
	public int reincarnation = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.monsterid = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.state = ba.ReadInt();
		this.mapid = ba.ReadInt();
		this.hp = ba.ReadInt();
		this.mp = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.reborn_pos = new p_pos();
			this.reborn_pos.fill2c(ba);
		}
		this.first_enemies = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_enemy p = new p_enemy();
			p.fill2c(ba);
			this.first_enemies.Add(p);
		}
		this.second_enemies = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_enemy p = new p_enemy();
			p.fill2c(ba);
			this.second_enemies.Add(p);
		}
		this.third_enemies = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_enemy p = new p_enemy();
			p.fill2c(ba);
			this.third_enemies.Add(p);
		}
		this.max_mp = ba.ReadInt();
		this.max_hp = ba.ReadInt();
		this.buffs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_actor_buf p = new p_actor_buf();
			p.fill2c(ba);
			this.buffs.Add(p);
		}
		this.monstername = ba.ReadString();
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
		this.min_attack = ba.ReadInt();
		this.max_attack = ba.ReadInt();
		this.phy_anti = ba.ReadInt();
		this.magic_anti = ba.ReadInt();
		this.poisoning_resist = ba.ReadInt();
		this.dizzy_resist = ba.ReadInt();
		this.freeze_resist = ba.ReadInt();
		this.equip_score = ba.ReadInt();
		this.spec_score_one = ba.ReadInt();
		this.spec_score_two = ba.ReadInt();
		this.hit_rate = ba.ReadInt();
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
		this.reincarnation = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.monsterid);
		ba.WriteInt(this.typeid);
		ba.WriteInt(this.state);
		ba.WriteInt(this.mapid);
		ba.WriteInt(this.hp);
		ba.WriteInt(this.mp);
		this.pos.fill2s(ba);
		this.reborn_pos.fill2s(ba);
		for (int i = 0; i < first_enemies.Count; i++){
		((p_enemy)this.first_enemies[i]).fill2s(ba);		}
		for (int i = 0; i < second_enemies.Count; i++){
		((p_enemy)this.second_enemies[i]).fill2s(ba);		}
		for (int i = 0; i < third_enemies.Count; i++){
		((p_enemy)this.third_enemies[i]).fill2s(ba);		}
		ba.WriteInt(this.max_mp);
		ba.WriteInt(this.max_hp);
		for (int i = 0; i < buffs.Count; i++){
		((p_actor_buf)this.buffs[i]).fill2s(ba);		}
		ba.WriteString(this.monstername);
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
		ba.WriteInt(this.min_attack);
		ba.WriteInt(this.max_attack);
		ba.WriteInt(this.phy_anti);
		ba.WriteInt(this.magic_anti);
		ba.WriteInt(this.poisoning_resist);
		ba.WriteInt(this.dizzy_resist);
		ba.WriteInt(this.freeze_resist);
		ba.WriteInt(this.equip_score);
		ba.WriteInt(this.spec_score_one);
		ba.WriteInt(this.spec_score_two);
		ba.WriteInt(this.hit_rate);
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
		ba.WriteInt(this.reincarnation);
	}
}