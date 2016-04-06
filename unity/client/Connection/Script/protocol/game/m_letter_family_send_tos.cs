using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_family_send_tos:OutgoingBase{
	//ID
	public int protocolID = 2112;

	//fields
	public string text;
	public int range = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2112);
		ba.WriteString(this.text);
		ba.WriteInt(this.range);
	}
}