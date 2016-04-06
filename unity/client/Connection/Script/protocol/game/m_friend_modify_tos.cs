using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_modify_tos:OutgoingBase{
	//ID
	public int protocolID = 1009;

	//fields
	public p_role_ext info;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1009);
		this.info.fill2s(ba);
	}
}