using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_skill:GameNetInfo{
	//fields
	public int skill_id = 0;
	public int cur_level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.skill_id = ba.ReadInt();
		this.cur_level = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.skill_id);
		ba.WriteInt(this.cur_level);
	}
}