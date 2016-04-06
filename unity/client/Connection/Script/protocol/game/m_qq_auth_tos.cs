using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_qq_auth_tos:OutgoingBase{
	//ID
	public int protocolID = 9601;

	//fields
	public string account_name;
	public p_qq_token qq_token;
	public int os_type = 0;
	public string login_platform;
	public string client_version;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(9601);
		ba.WriteString(this.account_name);
		this.qq_token.fill2s(ba);
		ba.WriteInt(this.os_type);
		ba.WriteString(this.login_platform);
		ba.WriteString(this.client_version);
	}
}