using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_auto_agree_toc:IncommingBase{
	//ID
	public int protocolID = 3177;

	//fields
	public int is_auto_agree = 0;
	public int error_code = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.is_auto_agree = ba.ReadInt();
		this.error_code = ba.ReadInt();
	}
}