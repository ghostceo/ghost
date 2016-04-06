using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_caishen_confirm_tos:OutgoingBase{
	//ID
	public int protocolID = 10005;

	//fields
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(10005);
		ba.WriteInt(this.type);
	}
}