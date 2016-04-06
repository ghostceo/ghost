using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_schedule_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 5618;

	//fields
	public int error_code = 0;
	public string reason;
	public int id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.error_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.id = ba.ReadInt();
	}
}