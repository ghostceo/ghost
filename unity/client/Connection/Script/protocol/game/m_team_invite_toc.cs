using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_invite_toc:IncommingBase{
	//ID
	public int protocolID = 1701;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public string reason;
	public int role_id = 0;
	public string role_name;
	public int team_id = 0;
	public int pick_type = 0;
	public int leader_id = 0;
	public int type_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.team_id = ba.ReadInt();
		this.pick_type = ba.ReadInt();
		this.leader_id = ba.ReadInt();
		this.type_id = ba.ReadInt();
	}
}