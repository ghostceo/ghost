using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_activestate_tos:OutgoingBase{
	//ID
	public int protocolID = 3169;

	//fields
	public int family_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3169);
		ba.WriteInt(this.family_id);
	}
}