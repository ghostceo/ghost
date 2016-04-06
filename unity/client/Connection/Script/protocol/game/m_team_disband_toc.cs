using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_disband_toc:IncommingBase{
	//ID
	public int protocolID = 1708;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public int team_id = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.team_id = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}