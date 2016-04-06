using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_summon_tos:OutgoingBase{
	//ID
	public int protocolID = 1205;

	//fields
	public int pet_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1205);
		ba.WriteInt(this.pet_id);
	}
}