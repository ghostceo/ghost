using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_completion_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 5631;

	//fields
	public int reward_point = 0;
	public int err_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.reward_point = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}