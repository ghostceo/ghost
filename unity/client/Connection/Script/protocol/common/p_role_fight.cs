using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_fight:GameNetInfo{
	//fields
	public int role_id = 0;
	public int hp = 0;
	public int mp = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.hp = ba.ReadInt();
		this.mp = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.hp);
		ba.WriteInt(this.mp);
	}
}