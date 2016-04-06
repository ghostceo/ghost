using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_info_change:GameNetInfo{
	//fields
	public int change_type = 0;
	public int new_value = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.change_type = ba.ReadInt();
		this.new_value = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.change_type);
		ba.WriteInt(this.new_value);
	}
}