using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_war_use_buff_tos:OutgoingBase{
	//ID
	public int protocolID = 18003;

	//fields
	public int buff = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(18003);
		ba.WriteInt(this.buff);
	}
}