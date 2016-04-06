using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlshop_list_tos:OutgoingBase{
	//ID
	public int protocolID = 4901;

	//fields
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(4901);
	}
}