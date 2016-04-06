using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_online_broadcast_toc:IncommingBase{
	//ID
	public int protocolID = 537;

	//fields
	public int role_type = 0;
	public string role_name;
	public int faction_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_type = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.faction_id = ba.ReadInt();
	}
}