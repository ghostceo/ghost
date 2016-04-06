using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_trap:GameNetInfo{
	//fields
	public int trap_id = 0;
	public int owner_id = 0;
	public string owner_name;
	public int owner_type = 0;
	public int faction_id = 0;
	public int family_id = 0;
	public int team_id = 0;
	public int pk_mode = 0;
	public int target_area = 0;
	public ArrayList effects;
	public ArrayList buffs;
	public int skill_id = 0;
	public p_pos pos;
	public int remove_time = 0;
	public int trap_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.trap_id = ba.ReadInt();
		this.owner_id = ba.ReadInt();
		this.owner_name = ba.ReadString();
		this.owner_type = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.family_id = ba.ReadInt();
		this.team_id = ba.ReadInt();
		this.pk_mode = ba.ReadInt();
		this.target_area = ba.ReadInt();
		this.effects = new ArrayList();
		ba.ReadIntArray(this.effects);
		this.buffs = new ArrayList();
		ba.ReadIntArray(this.buffs);
		this.skill_id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.remove_time = ba.ReadInt();
		this.trap_type = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.trap_id);
		ba.WriteInt(this.owner_id);
		ba.WriteString(this.owner_name);
		ba.WriteInt(this.owner_type);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.family_id);
		ba.WriteInt(this.team_id);
		ba.WriteInt(this.pk_mode);
		ba.WriteInt(this.target_area);
		ba.WriteIntArray(this.effects);
		ba.WriteIntArray(this.buffs);
		ba.WriteInt(this.skill_id);
		this.pos.fill2s(ba);
		ba.WriteInt(this.remove_time);
		ba.WriteInt(this.trap_type);
	}
}