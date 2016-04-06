using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_move_walk_path_toc:IncommingBase{
	//ID
	public int protocolID = 701;

	//fields
	public int roleid = 0;
	public p_walk_path walk_path;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.walk_path = new p_walk_path();
			this.walk_path.fill2c(ba);
		}
	}
}