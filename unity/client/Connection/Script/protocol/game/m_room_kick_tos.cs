using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_room_kick_tos:OutgoingBase{
	//ID
	public int protocolID = 17105;

	//fields
	public int room_type = 0;
	public int role_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(17105);
		ba.WriteInt(this.room_type);
		ba.WriteInt(this.role_id);
	}
}