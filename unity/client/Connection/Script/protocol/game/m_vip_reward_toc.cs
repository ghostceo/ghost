using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_reward_toc:IncommingBase{
	//ID
	public int protocolID = 7408;

	//fields
	public bool succ = true;
	public int reason_code = 0;
	public int type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason_code = ba.ReadInt();
		this.type = ba.ReadInt();
	}
}