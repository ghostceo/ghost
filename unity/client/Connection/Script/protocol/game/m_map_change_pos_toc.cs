using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_change_pos_toc:IncommingBase{
	//ID
	public int protocolID = 308;

	//fields
	public int tx = 0;
	public int ty = 0;
	public int change_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.tx = ba.ReadInt();
		this.ty = ba.ReadInt();
		this.change_type = ba.ReadInt();
	}
}