using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_reward_fb_info:GameNetInfo{
	//fields
	public int pass_id = 0;
	public bool is_fetch = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pass_id = ba.ReadInt();
		this.is_fetch = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.pass_id);
		ba.WriteBool(this.is_fetch);
	}
}