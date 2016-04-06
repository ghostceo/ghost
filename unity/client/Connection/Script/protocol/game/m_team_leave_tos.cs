using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_leave_tos:OutgoingBase{
	//ID
	public int protocolID = 1704;

	//fields
	public int team_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1704);
		ba.WriteInt(this.team_id);
	}
}