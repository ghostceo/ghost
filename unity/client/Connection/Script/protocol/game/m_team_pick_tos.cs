using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_pick_tos:OutgoingBase{
	//ID
	public int protocolID = 1709;

	//fields
	public int pick_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1709);
		ba.WriteInt(this.pick_type);
	}
}