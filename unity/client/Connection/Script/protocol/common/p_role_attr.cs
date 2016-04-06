using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_attr:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public double next_level_exp = 0;
	public double exp = 0;
	public int level = 0;
	public ArrayList equips;
	public p_skin skin;
	public int cur_energy = 0;
	public int max_energy = 0;
	public int gold = 0;
	public int gold_bind = 0;
	public double silver = 0;
	public double silver_bind = 0;
	public bool show_cloth = true;
	public int gongxun = 0;
	public string last_login_ip;
	public int office_id = 0;
	public string office_name;
	public bool unbund = false;
	public int family_contribute = 0;
	public int active_points = 0;
	public bool show_equip_ring = true;
	public bool is_payed = false;
	public double sum_prestige = 0;
	public double cur_prestige = 0;
	public int jingjie = 0;
	public ArrayList medals;
	public int firecoin = 0;
	public int juewei = 0;
	public int honor = 0;
	public int zhenqi = 0;
	public int reincarnation = 0;
	public int sanyuan = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.next_level_exp = ba.ReadDouble();
		this.exp = ba.ReadDouble();
		this.level = ba.ReadInt();
		this.equips = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.equips.Add(p);
		}
		if(ba.ReadByte() == 1){
			this.skin = new p_skin();
			this.skin.fill2c(ba);
		}
		this.cur_energy = ba.ReadInt();
		this.max_energy = ba.ReadInt();
		this.gold = ba.ReadInt();
		this.gold_bind = ba.ReadInt();
		this.silver = ba.ReadDouble();
		this.silver_bind = ba.ReadDouble();
		this.show_cloth = ba.ReadBoolean();
		this.gongxun = ba.ReadInt();
		this.last_login_ip = ba.ReadString();
		this.office_id = ba.ReadInt();
		this.office_name = ba.ReadString();
		this.unbund = ba.ReadBoolean();
		this.family_contribute = ba.ReadInt();
		this.active_points = ba.ReadInt();
		this.show_equip_ring = ba.ReadBoolean();
		this.is_payed = ba.ReadBoolean();
		this.sum_prestige = ba.ReadDouble();
		this.cur_prestige = ba.ReadDouble();
		this.jingjie = ba.ReadInt();
		this.medals = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_medal p = new p_medal();
			p.fill2c(ba);
			this.medals.Add(p);
		}
		this.firecoin = ba.ReadInt();
		this.juewei = ba.ReadInt();
		this.honor = ba.ReadInt();
		this.zhenqi = ba.ReadInt();
		this.reincarnation = ba.ReadInt();
		this.sanyuan = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteDouble(this.next_level_exp);
		ba.WriteDouble(this.exp);
		ba.WriteInt(this.level);
		for (int i = 0; i < equips.Count; i++){
		((p_goods)this.equips[i]).fill2s(ba);		}
		this.skin.fill2s(ba);
		ba.WriteInt(this.cur_energy);
		ba.WriteInt(this.max_energy);
		ba.WriteInt(this.gold);
		ba.WriteInt(this.gold_bind);
		ba.WriteDouble(this.silver);
		ba.WriteDouble(this.silver_bind);
		ba.WriteBool(this.show_cloth);
		ba.WriteInt(this.gongxun);
		ba.WriteString(this.last_login_ip);
		ba.WriteInt(this.office_id);
		ba.WriteString(this.office_name);
		ba.WriteBool(this.unbund);
		ba.WriteInt(this.family_contribute);
		ba.WriteInt(this.active_points);
		ba.WriteBool(this.show_equip_ring);
		ba.WriteBool(this.is_payed);
		ba.WriteDouble(this.sum_prestige);
		ba.WriteDouble(this.cur_prestige);
		ba.WriteInt(this.jingjie);
		for (int i = 0; i < medals.Count; i++){
		((p_medal)this.medals[i]).fill2s(ba);		}
		ba.WriteInt(this.firecoin);
		ba.WriteInt(this.juewei);
		ba.WriteInt(this.honor);
		ba.WriteInt(this.zhenqi);
		ba.WriteInt(this.reincarnation);
		ba.WriteInt(this.sanyuan);
	}
}