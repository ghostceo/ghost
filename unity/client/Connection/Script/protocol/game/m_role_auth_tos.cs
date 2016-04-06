using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role_auth_tos:OutgoingBase{
	//ID
	public int protocolID = 401;

	//fields
	public string account_name;
	public string key;
	public int os_type = 0;
	public string login_platform;
	public string client_version;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(401);
		ba.WriteString(this.account_name);
		ba.WriteString(this.key);
		ba.WriteInt(this.os_type);
		ba.WriteString(this.login_platform);
		ba.WriteString(this.client_version);
	}
}