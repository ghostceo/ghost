using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_compare_sell_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 17601;

	//fields
	public int id = 0;
	public int tag = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(17601);
		ba.WriteInt(this.id);
		ba.WriteInt(this.tag);
	}
}