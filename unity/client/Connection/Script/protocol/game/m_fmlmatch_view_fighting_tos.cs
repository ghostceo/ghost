using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlmatch_view_fighting_tos:OutgoingBase{
	//ID
	public int protocolID = 20402;

	//fields
	public int view_role_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(20402);
		ba.WriteInt(this.view_role_id);
	}
}