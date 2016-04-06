using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlbonus_send_toc:IncommingBase{
	//ID
	public int protocolID = 20303;

	//fields
	public int error_code = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.error_code = ba.ReadInt();
	}
}