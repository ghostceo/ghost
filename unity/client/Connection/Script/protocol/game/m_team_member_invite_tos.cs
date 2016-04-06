using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_member_invite_tos:OutgoingBase{
	//ID
	public int protocolID = 1712;

	//fields
	public int op_type = 0;
	public int member_id = 0;
	public string member_name;
	public int role_id = 0;
	public string role_name;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1712);
		ba.WriteInt(this.op_type);
		ba.WriteInt(this.member_id);
		ba.WriteString(this.member_name);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
	}
}