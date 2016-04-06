using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_drunk_time_toc:IncommingBase{
	//ID
	public int protocolID = 5620;

	//fields
	public int start_time = 0;
	public int end_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
	}
}