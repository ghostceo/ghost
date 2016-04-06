using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_stop_notify_tos:OutgoingBase{
	//ID
	public int protocolID = 7404;

	//fields
	public int notify_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(7404);
		ba.WriteInt(this.notify_type);
	}
}