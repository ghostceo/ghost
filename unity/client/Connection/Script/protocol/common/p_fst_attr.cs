using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_fst_attr:GameNetInfo{
	//fields
	public int str = 0;
	public int int2 = 0;
	public int dex = 0;
	public int con = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.str = ba.ReadInt();
		this.int2 = ba.ReadInt();
		this.dex = ba.ReadInt();
		this.con = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.str);
		ba.WriteInt(this.int2);
		ba.WriteInt(this.dex);
		ba.WriteInt(this.con);
	}
}