using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_skill_pos:GameNetInfo{
	//fields
	public int pos = 0;
	public int skill_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pos = ba.ReadInt();
		this.skill_id = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.pos);
		ba.WriteInt(this.skill_id);
	}
}