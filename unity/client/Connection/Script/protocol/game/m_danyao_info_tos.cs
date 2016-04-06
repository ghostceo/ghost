using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_danyao_info_tos:OutgoingBase{
	//ID
	public int protocolID = 3701;

	//fields
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3701);
		ba.WriteInt(this.type);
	}
}