using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_notice_start_tos:OutgoingBase{
	//ID
	public int protocolID = 5611;

	//fields
	public int activity_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(5611);
		ba.WriteInt(this.activity_id);
	}
}