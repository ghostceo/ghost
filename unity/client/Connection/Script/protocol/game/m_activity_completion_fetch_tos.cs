using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_completion_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 5631;

	//fields
	public int reward_point = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(5631);
		ba.WriteInt(this.reward_point);
	}
}