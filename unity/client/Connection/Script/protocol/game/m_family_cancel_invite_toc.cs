using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_cancel_invite_toc:IncommingBase{
	//ID
	public int protocolID = 3128;

	//fields
	public bool succ = true;
	public string reason;
	public bool return_self = true;
	public int role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		this.role_id = ba.ReadInt();
	}
}