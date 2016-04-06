using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_error_toc:IncommingBase{
	//ID
	public int protocolID = 3605;

	//fields
	public string error_info;
	public int error_no = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.error_info = ba.ReadString();
		this.error_no = ba.ReadInt();
	}
}