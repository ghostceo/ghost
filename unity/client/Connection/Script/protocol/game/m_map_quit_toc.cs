using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_quit_toc:IncommingBase{
	//ID
	public int protocolID = 302;

	//fields
	public int roleid = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
	}
}