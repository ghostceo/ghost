using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_collect_role:GameNetInfo{
	//fields
	public int roleid = 0;
	public int start_time = 0;
	public int end_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.roleid);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
	}
}