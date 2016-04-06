using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_offline_toc:IncommingBase{
	//ID
	public int protocolID = 1706;

	//fields
	public bool cache_offline = false;
	public ArrayList role_list;
	public int role_id = 0;
	public string role_name;
	public int team_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.cache_offline = ba.ReadBoolean();
		this.role_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_team_role p = new p_team_role();
			p.fill2c(ba);
			this.role_list.Add(p);
		}
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.team_id = ba.ReadInt();
	}
}