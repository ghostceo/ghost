using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_tidy_tos:OutgoingBase{
	//ID
	public int protocolID = 2708;

	//fields
	public int bagid = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2708);
		ba.WriteInt(this.bagid);
	}
}