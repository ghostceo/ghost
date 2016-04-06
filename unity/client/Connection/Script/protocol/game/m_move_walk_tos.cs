using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_move_walk_tos:OutgoingBase{
	//ID
	public int protocolID = 702;

	//fields
	public p_pos pos;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(702);
		this.pos.fill2s(ba);
	}
}