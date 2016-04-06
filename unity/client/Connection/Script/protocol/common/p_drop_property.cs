using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_drop_property:GameNetInfo{
	//fields
	public bool bind = false;
	public int colour = 0;
	public int quality = 0;
	public int hole_num = 0;
	public int use_bind = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.bind = ba.ReadBoolean();
		this.colour = ba.ReadInt();
		this.quality = ba.ReadInt();
		this.hole_num = ba.ReadInt();
		this.use_bind = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteBool(this.bind);
		ba.WriteInt(this.colour);
		ba.WriteInt(this.quality);
		ba.WriteInt(this.hole_num);
		ba.WriteInt(this.use_bind);
	}
}