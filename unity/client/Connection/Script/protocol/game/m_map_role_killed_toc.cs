using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_role_killed_toc:IncommingBase{
	//ID
	public int protocolID = 311;

	//fields
	public string role_name;
	public string killer_name;
	public int faction_id = 0;
	public int map_id = 0;
	public int tx = 0;
	public int ty = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_name = ba.ReadString();
		this.killer_name = ba.ReadString();
		this.faction_id = ba.ReadInt();
		this.map_id = ba.ReadInt();
		this.tx = ba.ReadInt();
		this.ty = ba.ReadInt();
	}
}