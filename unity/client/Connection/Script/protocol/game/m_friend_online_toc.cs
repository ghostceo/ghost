using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_online_toc:IncommingBase{
	//ID
	public int protocolID = 1004;

	//fields
	public int roleid = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
	}
}