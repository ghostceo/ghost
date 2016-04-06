using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_bet_role:GameNetInfo{
	//fields
	public int rand_id = 0;
	public int role_id = 0;
	public string role_name;
	public int type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rand_id = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.type = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rand_id);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.type);
	}
}