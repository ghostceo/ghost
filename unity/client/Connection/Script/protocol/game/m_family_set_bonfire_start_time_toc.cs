using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_set_bonfire_start_time_toc:IncommingBase{
	//ID
	public int protocolID = 3168;

	//fields
	public bool succ = true;
	public string reason;
	public int hour = 0;
	public int minute = 0;
	public int seconds = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.hour = ba.ReadInt();
		this.minute = ba.ReadInt();
		this.seconds = ba.ReadInt();
	}
}