using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_request_list_tos:OutgoingBase{
	//ID
	public int protocolID = 3184;

	//fields
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3184);
	}
}