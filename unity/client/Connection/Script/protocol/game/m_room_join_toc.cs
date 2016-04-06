using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_room_join_toc:IncommingBase{
	//ID
	public int protocolID = 17102;

	//fields
	public p_room_info room;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.room = new p_room_info();
			this.room.fill2c(ba);
		}
	}
}