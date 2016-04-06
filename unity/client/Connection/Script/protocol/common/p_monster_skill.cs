using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_monster_skill:GameNetInfo{
	//fields
	public int skillid = 0;
	public int level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.skillid = ba.ReadInt();
		this.level = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.skillid);
		ba.WriteInt(this.level);
	}
}