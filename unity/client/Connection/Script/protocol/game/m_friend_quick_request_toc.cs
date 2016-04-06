using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_quick_request_toc:IncommingBase{
	//ID
	public int protocolID = 1022;

	//fields
	public int err_code = 0;
	public string reason;
	public bool return_self = true;
	public string role_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		this.role_name = ba.ReadString();
	}
}