using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_scene_war_fb_query_tos:OutgoingBase{
	//ID
	public int protocolID = 7603;

	//fields
	public int op_type = 0;
	public int npc_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(7603);
		ba.WriteInt(this.op_type);
		ba.WriteInt(this.npc_id);
	}
}