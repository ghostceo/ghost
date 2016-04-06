using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_donate_tos:OutgoingBase{
	//ID
	public int protocolID = 3175;

	//fields
	public int donate_type = 0;
	public int donate_value = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3175);
		ba.WriteInt(this.donate_type);
		ba.WriteInt(this.donate_value);
	}
}