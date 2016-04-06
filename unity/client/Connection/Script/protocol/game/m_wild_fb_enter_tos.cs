using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_wild_fb_enter_tos:OutgoingBase{
	//ID
	public int protocolID = 19701;

	//fields
	public int wild_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(19701);
		ba.WriteInt(this.wild_type);
	}
}