using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_server_npc:GameNetInfo{
	//fields
	public int npc_id = 0;
	public int type_id = 0;
	public string npc_name;
	public int npc_type = 0;
	public int npc_kind_id = 0;
	public int state = 0;
	public int max_mp = 0;
	public double max_hp = 0;
	public double hp = 0;
	public int mp = 0;
	public int map_id = 0;
	public p_pos pos;
	public int move_speed = 0;
	public p_walk_path last_walk_path;
	public ArrayList state_buffs;
	public bool is_undead = true;
	public int npc_country = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.npc_id = ba.ReadInt();
		this.type_id = ba.ReadInt();
		this.npc_name = ba.ReadString();
		this.npc_type = ba.ReadInt();
		this.npc_kind_id = ba.ReadInt();
		this.state = ba.ReadInt();
		this.max_mp = ba.ReadInt();
		this.max_hp = ba.ReadDouble();
		this.hp = ba.ReadDouble();
		this.mp = ba.ReadInt();
		this.map_id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.move_speed = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.last_walk_path = new p_walk_path();
			this.last_walk_path.fill2c(ba);
		}
		this.state_buffs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_actor_buf p = new p_actor_buf();
			p.fill2c(ba);
			this.state_buffs.Add(p);
		}
		this.is_undead = ba.ReadBoolean();
		this.npc_country = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.npc_id);
		ba.WriteInt(this.type_id);
		ba.WriteString(this.npc_name);
		ba.WriteInt(this.npc_type);
		ba.WriteInt(this.npc_kind_id);
		ba.WriteInt(this.state);
		ba.WriteInt(this.max_mp);
		ba.WriteDouble(this.max_hp);
		ba.WriteDouble(this.hp);
		ba.WriteInt(this.mp);
		ba.WriteInt(this.map_id);
		this.pos.fill2s(ba);
		ba.WriteInt(this.move_speed);
		this.last_walk_path.fill2s(ba);
		for (int i = 0; i < state_buffs.Count; i++){
		((p_actor_buf)this.state_buffs[i]).fill2s(ba);		}
		ba.WriteBool(this.is_undead);
		ba.WriteInt(this.npc_country);
	}
}