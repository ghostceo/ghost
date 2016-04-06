using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_familyboss_person_rank:GameNetInfo{
	//fields
	public int order = 0;
	public int roleid = 0;
	public string name;
	public int category = 0;
	public int value = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.order = ba.ReadInt();
		this.roleid = ba.ReadInt();
		this.name = ba.ReadString();
		this.category = ba.ReadInt();
		this.value = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.order);
		ba.WriteInt(this.roleid);
		ba.WriteString(this.name);
		ba.WriteInt(this.category);
		ba.WriteInt(this.value);
	}
}