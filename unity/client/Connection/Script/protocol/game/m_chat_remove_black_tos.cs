using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_remove_black_tos:OutgoingBase{
	//ID
	public int protocolID = 910;

	//fields
	public string rolename;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(910);
		ba.WriteString(this.rolename);
	}
}