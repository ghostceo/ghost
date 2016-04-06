using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_disband_tos:OutgoingBase{
	//ID
	public int protocolID = 1708;

	//fields
	public int team_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1708);
		ba.WriteInt(this.team_id);
	}
}