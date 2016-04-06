using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_refuse_toc:IncommingBase{
	//ID
	public int protocolID = 1703;

	//fields
	public int role_id = 0;
	public string role_name;
	public int team_id = 0;
	public int type_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.team_id = ba.ReadInt();
		this.type_id = ba.ReadInt();
	}
}