using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_build_refresh_tos:OutgoingBase{
	//ID
	public int protocolID = 833;

	//fields
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(833);
	}
}