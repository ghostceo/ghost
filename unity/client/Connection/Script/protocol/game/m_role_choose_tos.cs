using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role_choose_tos:OutgoingBase{
	//ID
	public int protocolID = 404;

	//fields
	public int role_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(404);
		ba.WriteInt(this.role_id);
	}
}