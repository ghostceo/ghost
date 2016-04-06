using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_refuse_f_tos:OutgoingBase{
	//ID
	public int protocolID = 3107;

	//fields
	public int role_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3107);
		ba.WriteInt(this.role_id);
	}
}