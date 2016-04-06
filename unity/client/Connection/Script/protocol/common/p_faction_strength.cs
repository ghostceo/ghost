using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_faction_strength:GameNetInfo{
	//fields
	public int faction_id = 0;
	public int strength = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.faction_id = ba.ReadInt();
		this.strength = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.strength);
	}
}