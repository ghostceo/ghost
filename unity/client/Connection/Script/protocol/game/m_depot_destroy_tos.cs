using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_destroy_tos:OutgoingBase{
	//ID
	public int protocolID = 2703;

	//fields
	public int id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2703);
		ba.WriteInt(this.id);
	}
}