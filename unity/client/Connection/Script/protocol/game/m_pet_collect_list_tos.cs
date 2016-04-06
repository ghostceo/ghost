using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_collect_list_tos:OutgoingBase{
	//ID
	public int protocolID = 1209;

	//fields
	public int category = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1209);
		ba.WriteInt(this.category);
	}
}