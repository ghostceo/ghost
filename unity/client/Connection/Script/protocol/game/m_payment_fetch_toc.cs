using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_payment_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 19902;

	//fields
	public int type = 0;
	public bool is_fetched_first = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.is_fetched_first = ba.ReadBoolean();
	}
}