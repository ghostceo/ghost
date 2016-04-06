using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_nationbattle_quit_toc:IncommingBase{
	//ID
	public int protocolID = 9102;

	//fields
	public int error_code = 0;
	public string reason;
	public int type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.error_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.type = ba.ReadInt();
	}
}