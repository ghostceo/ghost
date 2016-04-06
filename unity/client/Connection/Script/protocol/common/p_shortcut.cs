using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_shortcut:GameNetInfo{
	//fields
	public int type = 0;
	public int id = 0;
	public string name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.id = ba.ReadInt();
		this.name = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type);
		ba.WriteInt(this.id);
		ba.WriteString(this.name);
	}
}