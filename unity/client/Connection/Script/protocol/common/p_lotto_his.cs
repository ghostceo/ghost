using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_lotto_his:GameNetInfo{
	//fields
	public string role_name;
	public int bonus = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_name = ba.ReadString();
		this.bonus = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteString(this.role_name);
		ba.WriteInt(this.bonus);
	}
}