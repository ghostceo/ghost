using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_bag_info_tos:OutgoingBase{
	//ID
	public int protocolID = 1208;

	//fields
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1208);
	}
}