using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_tower_fb_reward_toc:IncommingBase{
	//ID
	public int protocolID = 19304;

	//fields
	public bool succ = true;
	public int err_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}