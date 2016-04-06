using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_monster:GameNetInfo{
	//fields
	public int monsterid = 0;
	public int typeid = 0;
	public int state = 0;
	public int mapid = 0;
	public double hp = 0;
	public double mp = 0;
	public p_pos pos;
	public double max_mp = 0;
	public double max_hp = 0;
	public int move_speed = 0;
	public p_walk_path last_walk_path;
	public ArrayList state_buffs;
	public string monster_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.monsterid = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.state = ba.ReadInt();
		this.mapid = ba.ReadInt();
		this.hp = ba.ReadDouble();
		this.mp = ba.ReadDouble();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.max_mp = ba.ReadDouble();
		this.max_hp = ba.ReadDouble();
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
		this.monster_name = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.monsterid);
		ba.WriteInt(this.typeid);
		ba.WriteInt(this.state);
		ba.WriteInt(this.mapid);
		ba.WriteDouble(this.hp);
		ba.WriteDouble(this.mp);
		this.pos.fill2s(ba);
		ba.WriteDouble(this.max_mp);
		ba.WriteDouble(this.max_hp);
		ba.WriteInt(this.move_speed);
		this.last_walk_path.fill2s(ba);
		for (int i = 0; i < state_buffs.Count; i++){
		((p_actor_buf)this.state_buffs[i]).fill2s(ba);		}
		ba.WriteString(this.monster_name);
	}
}