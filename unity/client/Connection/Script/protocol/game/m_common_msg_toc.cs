using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_common_msg_toc:IncommingBase{
	//ID
	public int protocolID = 1402;

	//fields
	public string msg;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.msg = ba.ReadString();
	}
}