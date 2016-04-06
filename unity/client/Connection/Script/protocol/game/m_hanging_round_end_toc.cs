using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_round_end_toc:IncommingBase{
	//ID
	public int protocolID = 2313;

	//fields
	public int result = 0;
	public int wait_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.result = ba.ReadInt();
		this.wait_time = ba.ReadInt();
	}
}