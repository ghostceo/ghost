using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_change_leader_tos:OutgoingBase{
	//ID
	public int protocolID = 1707;

	//fields
	public int team_id = 0;
	public int role_id = 0;
	public string role_name;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1707);
		ba.WriteInt(this.team_id);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
	}
}