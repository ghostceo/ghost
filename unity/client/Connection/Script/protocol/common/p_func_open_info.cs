using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_func_open_info:GameNetInfo{
	//fields
	public int func_id = 0;
	public bool is_open = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.func_id = ba.ReadInt();
		this.is_open = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.func_id);
		ba.WriteBool(this.is_open);
	}
}