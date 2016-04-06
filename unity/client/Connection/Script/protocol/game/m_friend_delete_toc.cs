using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_delete_toc:IncommingBase{
	//ID
	public int protocolID = 1003;

	//fields
	public bool succ = true;
	public int type = 0;
	public string reason;
	public bool return_self = true;
	public int roleid = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.type = ba.ReadInt();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		this.roleid = ba.ReadInt();
	}
}