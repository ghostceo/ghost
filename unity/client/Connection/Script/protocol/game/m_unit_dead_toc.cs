using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_unit_dead_toc:IncommingBase{
	//ID
	public int protocolID = 18204;

	//fields
	public string killer_type;
	public int killer_id = 0;
	public int unitid = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.killer_type = ba.ReadString();
		this.killer_id = ba.ReadInt();
		this.unitid = ba.ReadInt();
	}
}