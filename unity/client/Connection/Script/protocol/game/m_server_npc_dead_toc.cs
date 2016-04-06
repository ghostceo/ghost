using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_server_npc_dead_toc:IncommingBase{
	//ID
	public int protocolID = 5003;

	//fields
	public int npc_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.npc_id = ba.ReadInt();
	}
}