using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_npc_tos:OutgoingBase{
	//ID
	public int protocolID = 1305;

	//fields
	public int npc_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1305);
		ba.WriteInt(this.npc_id);
	}
}