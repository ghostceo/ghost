using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_auth_tos:OutgoingBase{
	//ID
	public int protocolID = 901;

	//fields
	public string account;
	public int roleid = 0;
	public string key;
	public int timestamp = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(901);
		ba.WriteString(this.account);
		ba.WriteInt(this.roleid);
		ba.WriteString(this.key);
		ba.WriteInt(this.timestamp);
	}
}