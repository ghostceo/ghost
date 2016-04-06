using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_tower_fb_status_toc:IncommingBase{
	//ID
	public int protocolID = 19306;

	//fields
	public int left_times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.left_times = ba.ReadInt();
	}
}