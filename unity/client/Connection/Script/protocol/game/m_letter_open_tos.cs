using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_open_tos:OutgoingBase{
	//ID
	public int protocolID = 2107;

	//fields
	public int letter_id = 0;
	public int table = 0;
	public bool is_self_send = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2107);
		ba.WriteInt(this.letter_id);
		ba.WriteInt(this.table);
		ba.WriteBool(this.is_self_send);
	}
}