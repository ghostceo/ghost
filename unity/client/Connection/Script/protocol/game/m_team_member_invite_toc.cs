using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_member_invite_toc:IncommingBase{
	//ID
	public int protocolID = 1712;

	//fields
	public int op_status = 0;
	public int member_id = 0;
	public string member_name;
	public int role_id = 0;
	public string role_name;
	public bool succ = true;
	public bool return_self = true;
	public string reason;
	public int op_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.op_status = ba.ReadInt();
		this.member_id = ba.ReadInt();
		this.member_name = ba.ReadString();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.op_type = ba.ReadInt();
	}
}