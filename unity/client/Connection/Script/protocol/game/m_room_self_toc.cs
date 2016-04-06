using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_room_self_toc:IncommingBase{
	//ID
	public int protocolID = 17103;

	//fields
	public bool has_room = true;
	public p_room_info room;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.has_room = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.room = new p_room_info();
			this.room.fill2c(ba);
		}
	}
}