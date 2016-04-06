using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_skill_precondition:GameNetInfo{
	//fields
	public int skill_id = 0;
	public int skill_level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.skill_id = ba.ReadInt();
		this.skill_level = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.skill_id);
		ba.WriteInt(this.skill_level);
	}
}