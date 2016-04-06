using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_equip_bind_attr:GameNetInfo{
	//fields
	public int attr_code = 0;
	public int attr_level = 0;
	public int type = 0;
	public int value = 0;
	public int status = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.attr_code = ba.ReadInt();
		this.attr_level = ba.ReadInt();
		this.type = ba.ReadInt();
		this.value = ba.ReadInt();
		this.status = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.attr_code);
		ba.WriteInt(this.attr_level);
		ba.WriteInt(this.type);
		ba.WriteInt(this.value);
		ba.WriteInt(this.status);
	}
}