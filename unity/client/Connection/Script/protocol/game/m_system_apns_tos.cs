using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_apns_tos:OutgoingBase{
	//ID
	public int protocolID = 3608;

	//fields
	public string login_platform;
	public string machine_addr;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3608);
		ba.WriteString(this.login_platform);
		ba.WriteString(this.machine_addr);
	}
}