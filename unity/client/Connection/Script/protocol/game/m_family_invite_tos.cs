using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_invite_tos:OutgoingBase{
	//ID
	public int protocolID = 3103;

	//fields
	public string role_name;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3103);
		ba.WriteString(this.role_name);
	}
}