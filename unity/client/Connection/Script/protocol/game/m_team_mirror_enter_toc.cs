using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_mirror_enter_toc:IncommingBase{
	//ID
	public int protocolID = 17901;

	//fields
	public int succ = 0;
	public string reason;
	public int fb_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadInt();
		this.reason = ba.ReadString();
		this.fb_id = ba.ReadInt();
	}
}