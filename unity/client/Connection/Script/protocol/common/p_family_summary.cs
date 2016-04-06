using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_summary:GameNetInfo{
	//fields
	public int id = 0;
	public string name;
	public int create_role_id = 0;
	public string create_role_name;
	public int owner_role_id = 0;
	public string owner_role_name;
	public int cur_members = 0;
	public int faction_id = 0;
	public int level = 0;
	public int active_points = 0;
	public int rank = 0;
	public int badge = 0;
	public int max_member = 0;
	public string public_notice;
	public int relationship_to_role = 0;
	public int limit_level = 0;
	public int limit_fight_power = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.name = ba.ReadString();
		this.create_role_id = ba.ReadInt();
		this.create_role_name = ba.ReadString();
		this.owner_role_id = ba.ReadInt();
		this.owner_role_name = ba.ReadString();
		this.cur_members = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.active_points = ba.ReadInt();
		this.rank = ba.ReadInt();
		this.badge = ba.ReadInt();
		this.max_member = ba.ReadInt();
		this.public_notice = ba.ReadString();
		this.relationship_to_role = ba.ReadInt();
		this.limit_level = ba.ReadInt();
		this.limit_fight_power = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteString(this.name);
		ba.WriteInt(this.create_role_id);
		ba.WriteString(this.create_role_name);
		ba.WriteInt(this.owner_role_id);
		ba.WriteString(this.owner_role_name);
		ba.WriteInt(this.cur_members);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.active_points);
		ba.WriteInt(this.rank);
		ba.WriteInt(this.badge);
		ba.WriteInt(this.max_member);
		ba.WriteString(this.public_notice);
		ba.WriteInt(this.relationship_to_role);
		ba.WriteInt(this.limit_level);
		ba.WriteInt(this.limit_fight_power);
	}
}