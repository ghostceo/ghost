using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_gift_tos:OutgoingBase{
	//ID
	public int protocolID = 7415;

	//fields
	public int vip_level = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(7415);
		ba.WriteInt(this.vip_level);
	}
}