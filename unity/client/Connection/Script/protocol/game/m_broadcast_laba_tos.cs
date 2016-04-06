using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_broadcast_laba_tos:OutgoingBase{
	//ID
	public int protocolID = 2919;

	//fields
	public string content;
	public int laba_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2919);
		ba.WriteString(this.content);
		ba.WriteInt(this.laba_id);
	}
}