using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_room_exit_tos:OutgoingBase{
	//ID
	public int protocolID = 17104;

	//fields
	public int room_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(17104);
		ba.WriteInt(this.room_type);
	}
}