using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_auto_agree_tos:OutgoingBase{
	//ID
	public int protocolID = 3177;

	//fields
	public int is_auto_agree = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3177);
		ba.WriteInt(this.is_auto_agree);
	}
}