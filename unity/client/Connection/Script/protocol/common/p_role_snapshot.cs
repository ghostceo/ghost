using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_snapshot:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int category = 0;
	public int fightpower = 0;
	public int level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.category = ba.ReadInt();
		this.fightpower = ba.ReadInt();
		this.level = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.category);
		ba.WriteInt(this.fightpower);
		ba.WriteInt(this.level);
	}
}