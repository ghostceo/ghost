using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_message_toc:IncommingBase{
	//ID
	public int protocolID = 3606;

	//fields
	public string message;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.message = ba.ReadString();
	}
}