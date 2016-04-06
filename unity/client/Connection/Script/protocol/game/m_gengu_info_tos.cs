using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_gengu_info_tos:OutgoingBase{
	//ID
	public int protocolID = 17501;

	//fields
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(17501);
	}
}