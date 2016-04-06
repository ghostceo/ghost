using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_open_activity_info_tos:OutgoingBase{
	//ID
	public int protocolID = 5633;

	//fields
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(5633);
		ba.WriteInt(this.type);
	}
}