using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_activity_pay_gift_info:GameNetInfo{
	//fields
	public int type = 0;
	public int id = 0;
	public bool is_fetch = false;
	public bool is_reached = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.id = ba.ReadInt();
		this.is_fetch = ba.ReadBoolean();
		this.is_reached = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type);
		ba.WriteInt(this.id);
		ba.WriteBool(this.is_fetch);
		ba.WriteBool(this.is_reached);
	}
}