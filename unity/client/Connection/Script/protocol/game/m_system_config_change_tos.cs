using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_config_change_tos:OutgoingBase{
	//ID
	public int protocolID = 3603;

	//fields
	public p_sys_config sys_config;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3603);
		this.sys_config.fill2s(ba);
	}
}