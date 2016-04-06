using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_heartbeat_toc:IncommingBase{
	//ID
	public int protocolID = 3604;

	//fields
	public int time = 0;
	public int server_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.time = ba.ReadInt();
		this.server_time = ba.ReadInt();
	}
}