using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_boss_call_tos:OutgoingBase{
	//ID
	public int protocolID = 3180;

	//fields
	public int boss_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3180);
		ba.WriteInt(this.boss_type);
	}
}