using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_unbund_change_tos:OutgoingBase{
	//ID
	public int protocolID = 523;

	//fields
	public bool unbund = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(523);
		ba.WriteBool(this.unbund);
	}
}