using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_apply_toc:IncommingBase{
	//ID
	public int protocolID = 1714;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public int role_id = 0;
	public int op_type = 0;
	public int apply_id = 0;
	public string apply_name;
	public string reason;
	public ArrayList role_list;
	public int team_id = 0;
	public int pick_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.role_id = ba.ReadInt();
		this.op_type = ba.ReadInt();
		this.apply_id = ba.ReadInt();
		this.apply_name = ba.ReadString();
		this.reason = ba.ReadString();
		this.role_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_team_role p = new p_team_role();
			p.fill2c(ba);
			this.role_list.Add(p);
		}
		this.team_id = ba.ReadInt();
		this.pick_type = ba.ReadInt();
	}
}