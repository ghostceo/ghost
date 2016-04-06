using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_caishen_silver_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 10002;

	//fields
	public bool is_use_item = false;
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(10002);
		ba.WriteBool(this.is_use_item);
		ba.WriteInt(this.type);
	}
}