using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_boss_ai_skill:GameNetInfo{
	//fields
	public int skill_id = 0;
	public int skill_level = 0;
	public int weight = 0;
	public int parm = 0;
	public bool reset_attacktime = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.skill_id = ba.ReadInt();
		this.skill_level = ba.ReadInt();
		this.weight = ba.ReadInt();
		this.parm = ba.ReadInt();
		this.reset_attacktime = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.skill_id);
		ba.WriteInt(this.skill_level);
		ba.WriteInt(this.weight);
		ba.WriteInt(this.parm);
		ba.WriteBool(this.reset_attacktime);
	}
}