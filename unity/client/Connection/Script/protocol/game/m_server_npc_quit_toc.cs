using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_server_npc_quit_toc:IncommingBase{
	//ID
	public int protocolID = 5002;

	//fields
	public ArrayList npc_ids;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.npc_ids = new ArrayList();
		ba.ReadIntArray(this.npc_ids);
	}
}