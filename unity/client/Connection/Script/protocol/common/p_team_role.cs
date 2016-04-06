using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_team_role:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int sex = 0;
	public p_skin skin;
	public int map_id = 0;
	public string map_name;
	public int tx = 0;
	public int ty = 0;
	public int hp = 0;
	public int mp = 0;
	public int max_hp = 0;
	public int max_mp = 0;
	public int level = 0;
	public bool is_leader = false;
	public bool is_follow = false;
	public bool is_offline = false;
	public int offline_time = 0;
	public int add_hp = 0;
	public int add_mp = 0;
	public int add_phy_attack = 0;
	public int add_magic_attack = 0;
	public int category = 0;
	public int faction_id = 0;
	public int reincarnation = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.sex = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.skin = new p_skin();
			this.skin.fill2c(ba);
		}
		this.map_id = ba.ReadInt();
		this.map_name = ba.ReadString();
		this.tx = ba.ReadInt();
		this.ty = ba.ReadInt();
		this.hp = ba.ReadInt();
		this.mp = ba.ReadInt();
		this.max_hp = ba.ReadInt();
		this.max_mp = ba.ReadInt();
		this.level = ba.ReadInt();
		this.is_leader = ba.ReadBoolean();
		this.is_follow = ba.ReadBoolean();
		this.is_offline = ba.ReadBoolean();
		this.offline_time = ba.ReadInt();
		this.add_hp = ba.ReadInt();
		this.add_mp = ba.ReadInt();
		this.add_phy_attack = ba.ReadInt();
		this.add_magic_attack = ba.ReadInt();
		this.category = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.reincarnation = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.sex);
		this.skin.fill2s(ba);
		ba.WriteInt(this.map_id);
		ba.WriteString(this.map_name);
		ba.WriteInt(this.tx);
		ba.WriteInt(this.ty);
		ba.WriteInt(this.hp);
		ba.WriteInt(this.mp);
		ba.WriteInt(this.max_hp);
		ba.WriteInt(this.max_mp);
		ba.WriteInt(this.level);
		ba.WriteBool(this.is_leader);
		ba.WriteBool(this.is_follow);
		ba.WriteBool(this.is_offline);
		ba.WriteInt(this.offline_time);
		ba.WriteInt(this.add_hp);
		ba.WriteInt(this.add_mp);
		ba.WriteInt(this.add_phy_attack);
		ba.WriteInt(this.add_magic_attack);
		ba.WriteInt(this.category);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.reincarnation);
	}
}