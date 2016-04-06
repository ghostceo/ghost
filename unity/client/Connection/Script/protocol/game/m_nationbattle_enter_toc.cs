using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_nationbattle_enter_toc:IncommingBase{
	//ID
	public int protocolID = 9101;

	//fields
	public int enter_type = 0;
	public int error_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.enter_type = ba.ReadInt();
		this.error_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}