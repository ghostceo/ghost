using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_stat_client_os_tos:OutgoingBase{
	//ID
	public int protocolID = 6401;

	//fields
	public int os_type = 0;
	public string os_version;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(6401);
		ba.WriteInt(this.os_type);
		ba.WriteString(this.os_version);
	}
}