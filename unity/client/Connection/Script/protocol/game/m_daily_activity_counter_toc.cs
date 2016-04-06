using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_daily_activity_counter_toc:IncommingBase{
	//ID
	public int protocolID = 18602;

	//fields
	public int id = 0;
	public int counter = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.counter = ba.ReadInt();
	}
}