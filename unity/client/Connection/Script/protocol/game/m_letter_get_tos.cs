using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_get_tos:OutgoingBase{
	//ID
	public int protocolID = 2104;

	//fields
	public int pack_num = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2104);
		ba.WriteInt(this.pack_num);
	}
}