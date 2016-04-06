using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_move_sync_toc:IncommingBase{
	//ID
	public int protocolID = 705;

	//fields
	public int roleid = 0;
	public p_pos pos;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
	}
}