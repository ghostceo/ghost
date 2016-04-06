using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_upgrade_toc:IncommingBase{
	//ID
	public int protocolID = 1016;

	//fields
	public int roleid = 0;
	public int oldlevel = 0;
	public int newlevel = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
		this.oldlevel = ba.ReadInt();
		this.newlevel = ba.ReadInt();
	}
}