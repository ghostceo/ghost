using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_show_equip_ring_tos:OutgoingBase{
	//ID
	public int protocolID = 533;

	//fields
	public bool show_equip_ring = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(533);
		ba.WriteBool(this.show_equip_ring);
	}
}