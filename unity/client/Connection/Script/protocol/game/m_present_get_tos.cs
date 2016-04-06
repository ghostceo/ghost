using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_present_get_tos:OutgoingBase{
	//ID
	public int protocolID = 6802;

	//fields
	public int present_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(6802);
		ba.WriteInt(this.present_id);
	}
}