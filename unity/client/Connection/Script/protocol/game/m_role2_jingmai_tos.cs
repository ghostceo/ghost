using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_jingmai_tos:OutgoingBase{
	//ID
	public int protocolID = 567;

	//fields
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(567);
		ba.WriteInt(this.type);
	}
}