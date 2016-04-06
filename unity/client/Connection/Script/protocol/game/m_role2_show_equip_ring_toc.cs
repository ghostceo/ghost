using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_show_equip_ring_toc:IncommingBase{
	//ID
	public int protocolID = 533;

	//fields
	public bool succ = true;
	public string reason;
	public bool show_equip_ring = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.show_equip_ring = ba.ReadBoolean();
	}
}