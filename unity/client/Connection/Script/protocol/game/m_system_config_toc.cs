using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_config_toc:IncommingBase{
	//ID
	public int protocolID = 3602;

	//fields
	public p_sys_config sys_config;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.sys_config = new p_sys_config();
			this.sys_config.fill2c(ba);
		}
	}
}