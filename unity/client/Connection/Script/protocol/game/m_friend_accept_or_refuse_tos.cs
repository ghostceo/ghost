using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_accept_or_refuse_tos:OutgoingBase{
	//ID
	public int protocolID = 1031;

	//fields
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1031);
		ba.WriteInt(this.type);
	}
}