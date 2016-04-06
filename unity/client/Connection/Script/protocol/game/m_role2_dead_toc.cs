using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_dead_toc:IncommingBase{
	//ID
	public int protocolID = 505;

	//fields
	public string killer;
	public ArrayList relive_type;
	public int relive_silver = 0;
	public int dead_type = 0;
	public int killer_faction = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.killer = ba.ReadString();
		this.relive_type = new ArrayList();
		ba.ReadIntArray(this.relive_type);
		this.relive_silver = ba.ReadInt();
		this.dead_type = ba.ReadInt();
		this.killer_faction = ba.ReadInt();
	}
}