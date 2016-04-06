using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_active_attr:GameNetInfo{
	//fields
	public int active_id = 0;
	public ArrayList progress;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.active_id = ba.ReadInt();
		this.progress = new ArrayList();
		ba.ReadIntArray(this.progress);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.active_id);
		ba.WriteIntArray(this.progress);
	}
}