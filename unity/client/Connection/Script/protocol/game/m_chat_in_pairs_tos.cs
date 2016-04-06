using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_in_pairs_tos:OutgoingBase{
	//ID
	public int protocolID = 903;

	//fields
	public string msg;
	public string to_rolename;
	public int show_type = 1;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(903);
		ba.WriteString(this.msg);
		ba.WriteString(this.to_rolename);
		ba.WriteInt(this.show_type);
	}
}