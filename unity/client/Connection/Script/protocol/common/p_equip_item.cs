using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_equip_item:GameNetInfo{
	//fields
	public int typeid = 0;
	public int color = 0;
	public int quality = 0;
	public int isbind = 0;
	public int timelimit = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.typeid = ba.ReadInt();
		this.color = ba.ReadInt();
		this.quality = ba.ReadInt();
		this.isbind = ba.ReadInt();
		this.timelimit = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.typeid);
		ba.WriteInt(this.color);
		ba.WriteInt(this.quality);
		ba.WriteInt(this.isbind);
		ba.WriteInt(this.timelimit);
	}
}