using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_black_delete_toc:IncommingBase{
	//ID
	public int protocolID = 1030;

	//fields
	public int roleid = 0;
	public bool succ = true;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
	}
}