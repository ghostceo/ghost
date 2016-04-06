using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_move_walk_path_tos:OutgoingBase{
	//ID
	public int protocolID = 701;

	//fields
	public p_walk_path walk_path;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(701);
		this.walk_path.fill2s(ba);
	}
}