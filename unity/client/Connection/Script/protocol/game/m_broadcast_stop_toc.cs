using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_broadcast_stop_toc:IncommingBase{
	//ID
	public int protocolID = 2920;

	//fields
	public int secs = 0;
	public string content;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.secs = ba.ReadInt();
		this.content = ba.ReadString();
	}
}