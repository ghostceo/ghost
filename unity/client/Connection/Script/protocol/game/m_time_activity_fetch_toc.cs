using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_time_activity_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 19502;

	//fields
	public int type = 0;
	public int id = 0;
	public int left_times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.id = ba.ReadInt();
		this.left_times = ba.ReadInt();
	}
}