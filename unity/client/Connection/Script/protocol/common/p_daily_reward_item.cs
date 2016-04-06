using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_daily_reward_item:GameNetInfo{
	//fields
	public int type_id = 0;
	public int type = 0;
	public int num = 0;
	public bool bind = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type_id = ba.ReadInt();
		this.type = ba.ReadInt();
		this.num = ba.ReadInt();
		this.bind = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type_id);
		ba.WriteInt(this.type);
		ba.WriteInt(this.num);
		ba.WriteBool(this.bind);
	}
}