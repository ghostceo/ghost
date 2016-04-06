using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_panel_tos:OutgoingBase{
	//ID
	public int protocolID = 3121;

	//fields
	public int num_per_page = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3121);
		ba.WriteInt(this.num_per_page);
	}
}