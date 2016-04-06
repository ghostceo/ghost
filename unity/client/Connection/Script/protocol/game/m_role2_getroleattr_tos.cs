using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_getroleattr_tos:OutgoingBase{
	//ID
	public int protocolID = 510;

	//fields
	public int role_id = 0;
	public bool is_check = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(510);
		ba.WriteInt(this.role_id);
		ba.WriteBool(this.is_check);
	}
}