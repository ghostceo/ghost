using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_invite_toc:IncommingBase{
	//ID
	public int protocolID = 3103;

	//fields
	public bool succ = true;
	public string reason;
	public bool return_self = true;
	public string role_name;
	public int family_id = 0;
	public string family_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		this.role_name = ba.ReadString();
		this.family_id = ba.ReadInt();
		this.family_name = ba.ReadString();
	}
}