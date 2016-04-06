using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_pos:GameNetInfo{
	//fields
	public int tx = 0;
	public int ty = 0;
	public int px = 0;
	public int py = 0;
	public int dir = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.tx = ba.ReadInt();
		this.ty = ba.ReadInt();
		this.px = ba.ReadInt();
		this.py = ba.ReadInt();
		this.dir = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.tx);
		ba.WriteInt(this.ty);
		ba.WriteInt(this.px);
		ba.WriteInt(this.py);
		ba.WriteInt(this.dir);
	}
}