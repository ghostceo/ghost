using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_stop_notify_toc:IncommingBase{
	//ID
	public int protocolID = 7404;

	//fields
	public bool succ = true;
	public string reason;
	public int notify_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.notify_type = ba.ReadInt();
	}
}