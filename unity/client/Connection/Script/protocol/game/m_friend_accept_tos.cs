using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_accept_tos:OutgoingBase{
	//ID
	public int protocolID = 1002;

	//fields
	public string name;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1002);
		ba.WriteString(this.name);
	}
}