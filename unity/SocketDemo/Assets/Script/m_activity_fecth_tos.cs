namespace LSocket.Type
{
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_fecth_tos:OutgoingBase{
	//ID
	public int protocolID = 5625;

	//fields
	public int npc_id = 0;

	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(14);
		ba.WriteInt(15);
		ba.WriteInt(this.npc_id);
	}
}
}