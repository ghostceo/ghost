using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_heartbeat_tos:OutgoingBase{
	//ID
	public int protocolID = 3604;

	//fields
	public int time = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3604);
		ba.WriteInt(this.time);
	}
}