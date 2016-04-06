using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_set_title_tos:OutgoingBase{
	//ID
	public int protocolID = 3116;

	//fields
	public int role_id = 0;
	public string title;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3116);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.title);
	}
}