using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_auto_list_toc:IncommingBase{
	//ID
	public int protocolID = 1711;

	//fields
	public bool return_self = true;
	public int team_id = 0;
	public ArrayList role_list;
	public int pick_type = 0;
	public ArrayList visible_role_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.return_self = ba.ReadBoolean();
		this.team_id = ba.ReadInt();
		this.role_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_team_role p = new p_team_role();
			p.fill2c(ba);
			this.role_list.Add(p);
		}
		this.pick_type = ba.ReadInt();
		this.visible_role_list = new ArrayList();
		ba.ReadIntArray(this.visible_role_list);
	}
}