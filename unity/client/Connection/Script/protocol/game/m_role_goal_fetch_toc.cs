using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role_goal_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 15501;

	//fields
	public int err_code = 0;
	public string reason;
	public int goal_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.goal_id = ba.ReadInt();
	}
}