using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_member_enter_map_tos:OutgoingBase{
	//ID
	public int protocolID = 3140;

	//fields
	public int call_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3140);
		ba.WriteInt(this.call_type);
	}
}