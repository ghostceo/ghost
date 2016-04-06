using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_stat_config_toc:IncommingBase{
	//ID
	public int protocolID = 6402;

	//fields
	public bool is_open = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.is_open = ba.ReadBoolean();
	}
}