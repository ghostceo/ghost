using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_room_kick_toc:IncommingBase{
	//ID
	public int protocolID = 17105;

	//fields
	public int room_type = 0;
	public int role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.room_type = ba.ReadInt();
		this.role_id = ba.ReadInt();
	}
}