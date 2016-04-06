using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_black_delete_tos:OutgoingBase{
	//ID
	public int protocolID = 1030;

	//fields
	public int roleid = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1030);
		ba.WriteInt(this.roleid);
	}
}