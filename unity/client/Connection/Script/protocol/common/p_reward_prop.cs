using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_reward_prop:GameNetInfo{
	//fields
	public int prop_id = 0;
	public int prop_num = 0;
	public bool bind = true;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.prop_id = ba.ReadInt();
		this.prop_num = ba.ReadInt();
		this.bind = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.prop_id);
		ba.WriteInt(this.prop_num);
		ba.WriteBool(this.bind);
	}
}