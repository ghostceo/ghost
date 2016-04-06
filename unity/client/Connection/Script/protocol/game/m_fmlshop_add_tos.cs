using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlshop_add_tos:OutgoingBase{
	//ID
	public int protocolID = 4902;

	//fields
	public int item_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(4902);
		ba.WriteInt(this.item_id);
	}
}