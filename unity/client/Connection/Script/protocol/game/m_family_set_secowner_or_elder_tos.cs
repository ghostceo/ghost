using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_set_secowner_or_elder_tos:OutgoingBase{
	//ID
	public int protocolID = 3118;

	//fields
	public int role_id = 0;
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3118);
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.type);
	}
}