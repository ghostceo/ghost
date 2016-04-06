using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlshop_error_toc:IncommingBase{
	//ID
	public int protocolID = 4900;

	//fields
	public int code = 0;
	public string msg;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.code = ba.ReadInt();
		this.msg = ba.ReadString();
	}
}