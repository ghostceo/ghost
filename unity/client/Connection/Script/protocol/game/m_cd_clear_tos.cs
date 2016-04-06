using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_cd_clear_tos:OutgoingBase{
	//ID
	public int protocolID = 18702;

	//fields
	public int cd_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(18702);
		ba.WriteInt(this.cd_type);
	}
}