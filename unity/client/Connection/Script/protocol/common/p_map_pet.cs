using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_pet:GameNetInfo{
	//fields
	public int pet_id = 0;
	public int type_id = 0;
	public string pet_name;
	public int state = 0;
	public int hp = 0;
	public p_pos pos;
	public int attack_speed = 0;
	public int max_hp = 0;
	public int role_id = 0;
	public ArrayList state_buffs;
	public int color = 0;
	public int star_lv = 0;
	public bool is_mirror = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.type_id = ba.ReadInt();
		this.pet_name = ba.ReadString();
		this.state = ba.ReadInt();
		this.hp = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.attack_speed = ba.ReadInt();
		this.max_hp = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.state_buffs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_actor_buf p = new p_actor_buf();
			p.fill2c(ba);
			this.state_buffs.Add(p);
		}
		this.color = ba.ReadInt();
		this.star_lv = ba.ReadInt();
		this.is_mirror = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.pet_id);
		ba.WriteInt(this.type_id);
		ba.WriteString(this.pet_name);
		ba.WriteInt(this.state);
		ba.WriteInt(this.hp);
		this.pos.fill2s(ba);
		ba.WriteInt(this.attack_speed);
		ba.WriteInt(this.max_hp);
		ba.WriteInt(this.role_id);
		for (int i = 0; i < state_buffs.Count; i++){
		((p_actor_buf)this.state_buffs[i]).fill2s(ba);		}
		ba.WriteInt(this.color);
		ba.WriteInt(this.star_lv);
		ba.WriteBool(this.is_mirror);
	}
}