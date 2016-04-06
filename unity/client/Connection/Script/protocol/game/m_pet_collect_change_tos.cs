using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_collect_change_tos:OutgoingBase{
	//ID
	public int protocolID = 1212;

	//fields
	public int type_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1212);
		ba.WriteInt(this.type_id);
	}
}