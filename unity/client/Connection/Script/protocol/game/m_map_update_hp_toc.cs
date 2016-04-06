using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_update_hp_toc:IncommingBase{
	//ID
	public int protocolID = 314;

	//fields
	public int actor_type = 0;
	public int actor_id = 0;
	public double actor_hp = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.actor_type = ba.ReadInt();
		this.actor_id = ba.ReadInt();
		this.actor_hp = ba.ReadDouble();
	}
}