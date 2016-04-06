using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_ybc:GameNetInfo{
	//fields
	public int ybc_id = 0;
	public int status = 0;
	public int hp = 0;
	public int max_hp = 0;
	public p_pos pos;
	public int move_speed = 0;
	public string name;
	public int create_type = 0;
	public int creator_id = 0;
	public int color = 0;
	public int create_time = 0;
	public int end_time = 0;
	public ArrayList buffs;
	public int group_id = 0;
	public int group_type = 0;
	public bool can_attack = false;
	public int faction_id = 0;
	public int physical_defence = 0;
	public int magic_defence = 0;
	public int recover_speed = 0;
	public int level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.ybc_id = ba.ReadInt();
		this.status = ba.ReadInt();
		this.hp = ba.ReadInt();
		this.max_hp = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.move_speed = ba.ReadInt();
		this.name = ba.ReadString();
		this.create_type = ba.ReadInt();
		this.creator_id = ba.ReadInt();
		this.color = ba.ReadInt();
		this.create_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.buffs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_actor_buf p = new p_actor_buf();
			p.fill2c(ba);
			this.buffs.Add(p);
		}
		this.group_id = ba.ReadInt();
		this.group_type = ba.ReadInt();
		this.can_attack = ba.ReadBoolean();
		this.faction_id = ba.ReadInt();
		this.physical_defence = ba.ReadInt();
		this.magic_defence = ba.ReadInt();
		this.recover_speed = ba.ReadInt();
		this.level = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.ybc_id);
		ba.WriteInt(this.status);
		ba.WriteInt(this.hp);
		ba.WriteInt(this.max_hp);
		this.pos.fill2s(ba);
		ba.WriteInt(this.move_speed);
		ba.WriteString(this.name);
		ba.WriteInt(this.create_type);
		ba.WriteInt(this.creator_id);
		ba.WriteInt(this.color);
		ba.WriteInt(this.create_time);
		ba.WriteInt(this.end_time);
		for (int i = 0; i < buffs.Count; i++){
		((p_actor_buf)this.buffs[i]).fill2s(ba);		}
		ba.WriteInt(this.group_id);
		ba.WriteInt(this.group_type);
		ba.WriteBool(this.can_attack);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.physical_defence);
		ba.WriteInt(this.magic_defence);
		ba.WriteInt(this.recover_speed);
		ba.WriteInt(this.level);
	}
}