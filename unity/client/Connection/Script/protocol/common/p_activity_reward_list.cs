using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_activity_reward_list:GameNetInfo{
	//fields
	public ArrayList status_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.status_list = new ArrayList();
		ba.ReadIntArray(this.status_list);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteIntArray(this.status_list);
	}
}