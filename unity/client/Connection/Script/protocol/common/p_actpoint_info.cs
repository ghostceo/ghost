using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_actpoint_info:GameNetInfo{
	//fields
	public int id = 0;
	public int cur_ap = 0;
	public int max_ap = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.cur_ap = ba.ReadInt();
		this.max_ap = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.cur_ap);
		ba.WriteInt(this.max_ap);
	}
}