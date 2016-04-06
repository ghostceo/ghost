using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_add_friendly_toc:IncommingBase{
	//ID
	public int protocolID = 1014;

	//fields
	public int role_id = 0;
	public int friendly = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.friendly = ba.ReadInt();
	}
}