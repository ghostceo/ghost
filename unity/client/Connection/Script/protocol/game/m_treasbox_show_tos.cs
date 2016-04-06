using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_treasbox_show_tos:OutgoingBase{
	//ID
	public int protocolID = 11801;

	//fields
	public int op_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(11801);
		ba.WriteInt(this.op_type);
	}
}