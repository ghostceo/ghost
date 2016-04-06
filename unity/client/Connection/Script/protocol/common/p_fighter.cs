using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_fighter:GameNetInfo{
	//fields
	public int actor_type = 0;
	public int actor_id = 0;
	public string actor_name;
	public int type_id = 0;
	public int level = 0;
	public int category = 0;
	public int color = 0;
	public int owner_id = 0;
	public int max_hp = 0;
	public int max_mp = 0;
	public int sanyuan = 0;
	public int quality = 0;
	public ArrayList skills;
	public int round_index = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.actor_type = ba.ReadInt();
		this.actor_id = ba.ReadInt();
		this.actor_name = ba.ReadString();
		this.type_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.category = ba.ReadInt();
		this.color = ba.ReadInt();
		this.owner_id = ba.ReadInt();
		this.max_hp = ba.ReadInt();
		this.max_mp = ba.ReadInt();
		this.sanyuan = ba.ReadInt();
		this.quality = ba.ReadInt();
		this.skills = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_skill p = new p_role_skill();
			p.fill2c(ba);
			this.skills.Add(p);
		}
		this.round_index = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.actor_type);
		ba.WriteInt(this.actor_id);
		ba.WriteString(this.actor_name);
		ba.WriteInt(this.type_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.category);
		ba.WriteInt(this.color);
		ba.WriteInt(this.owner_id);
		ba.WriteInt(this.max_hp);
		ba.WriteInt(this.max_mp);
		ba.WriteInt(this.sanyuan);
		ba.WriteInt(this.quality);
		for (int i = 0; i < skills.Count; i++){
		((p_role_skill)this.skills[i]).fill2s(ba);		}
		ba.WriteInt(this.round_index);
	}
}