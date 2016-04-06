using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_idol_error_toc:IncommingBase{
	//ID
	public int protocolID = 11700;

	//fields
	public int code = 0;
	public string mesg;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.code = ba.ReadInt();
		this.mesg = ba.ReadString();
	}
}