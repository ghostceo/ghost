using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_task:GameNetInfo{
	//fields
	public int id = 0;
	public int status = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.status = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.status);
	}
}