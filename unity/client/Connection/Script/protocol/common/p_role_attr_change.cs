using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_attr_change:GameNetInfo{
	//fields
	public int change_type = 0;
	public double new_value = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.change_type = ba.ReadInt();
		this.new_value = ba.ReadDouble();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.change_type);
		ba.WriteDouble(this.new_value);
	}
}