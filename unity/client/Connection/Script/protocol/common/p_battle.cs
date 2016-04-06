using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_battle:GameNetInfo{
	//fields
	public int battle_type = 0;
	public int id = 0;
	public int args = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.battle_type = ba.ReadInt();
		this.id = ba.ReadInt();
		this.args = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.battle_type);
		ba.WriteInt(this.id);
		ba.WriteInt(this.args);
	}
}