using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_create_toc:IncommingBase{
	//ID
	public int protocolID = 1716;

	//fields
	public int role_id = 0;
	public bool succ = true;
	public string reason;
	public int reason_code = 0;
	public ArrayList role_list;
	public int team_id = 0;
	public int pick_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.reason_code = ba.ReadInt();
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