using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_elder:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
	}
}