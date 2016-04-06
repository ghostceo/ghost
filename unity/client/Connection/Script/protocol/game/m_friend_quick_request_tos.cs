using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_quick_request_tos:OutgoingBase{
	//ID
	public int protocolID = 1022;

	//fields
	public ArrayList role_list;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1022);
		ba.WriteIntArray(this.role_list);
	}
}