using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_server_npc_enter_toc:IncommingBase{
	//ID
	public int protocolID = 5001;

	//fields
	public ArrayList server_npcs;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.server_npcs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_server_npc p = new p_map_server_npc();
			p.fill2c(ba);
			this.server_npcs.Add(p);
		}
	}
}