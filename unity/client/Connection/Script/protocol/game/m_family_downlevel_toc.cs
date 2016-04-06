using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_downlevel_toc:IncommingBase{
	//ID
	public int protocolID = 3136;

	//fields
	public int level = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.level = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}