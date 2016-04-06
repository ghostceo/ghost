using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_skill_level:GameNetInfo{
	//fields
	public int skill_id = 0;
	public int level = 0;
	public int base_attk_cnt = 0;
	public ArrayList pursued_skills;
	public int cool_time = 0;
	public int premise_role_level = 0;
	public int consume_mp = 0;
	public int aoe_type = 0;
	public ArrayList effects;
	public ArrayList buffs;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.skill_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.base_attk_cnt = ba.ReadInt();
		this.pursued_skills = new ArrayList();
		ba.ReadIntArray(this.pursued_skills);
		this.cool_time = ba.ReadInt();
		this.premise_role_level = ba.ReadInt();
		this.consume_mp = ba.ReadInt();
		this.aoe_type = ba.ReadInt();
		this.effects = new ArrayList();
		ba.ReadIntArray(this.effects);
		this.buffs = new ArrayList();
		ba.ReadIntArray(this.buffs);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.skill_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.base_attk_cnt);
		ba.WriteIntArray(this.pursued_skills);
		ba.WriteInt(this.cool_time);
		ba.WriteInt(this.premise_role_level);
		ba.WriteInt(this.consume_mp);
		ba.WriteInt(this.aoe_type);
		ba.WriteIntArray(this.effects);
		ba.WriteIntArray(this.buffs);
	}
}