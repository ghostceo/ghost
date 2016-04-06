using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_nationbattle_enter_tos:OutgoingBase{
	//ID
	public int protocolID = 9101;

	//fields
	public int enter_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(9101);
		ba.WriteInt(this.enter_type);
	}
}