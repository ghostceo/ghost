using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_pick_toc:IncommingBase{
	//ID
	public int protocolID = 1709;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public int pick_type = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.pick_type = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}