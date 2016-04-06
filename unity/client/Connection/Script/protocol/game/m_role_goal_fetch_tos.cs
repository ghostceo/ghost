using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role_goal_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 15501;

	//fields
	public int goal_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(15501);
		ba.WriteInt(this.goal_id);
	}
}