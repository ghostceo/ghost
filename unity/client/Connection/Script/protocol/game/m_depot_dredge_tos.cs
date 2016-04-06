using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_dredge_tos:OutgoingBase{
	//ID
	public int protocolID = 2702;

	//fields
	public int bagid = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2702);
		ba.WriteInt(this.bagid);
	}
}