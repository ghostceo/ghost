using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_get_info_tos:OutgoingBase{
	//ID
	public int protocolID = 1017;

	//fields
	public int roleid = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1017);
		ba.WriteInt(this.roleid);
	}
}