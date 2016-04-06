using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_gift_goods:GameNetInfo{
	//fields
	public int id = 0;
	public int type = 0;
	public int typeid = 0;
	public bool bind = false;
	public int start_time = 0;
	public int end_time = 0;
	public int num = 0;
	public int rate = 0;
	public int color = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.type = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.bind = ba.ReadBoolean();
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.num = ba.ReadInt();
		this.rate = ba.ReadInt();
		this.color = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.type);
		ba.WriteInt(this.typeid);
		ba.WriteBool(this.bind);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.num);
		ba.WriteInt(this.rate);
		ba.WriteInt(this.color);
	}
}