using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_grab_update_role_toc:IncommingBase{
	//ID
	public int protocolID = 11008;

	//fields
	public p_grab_role role;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.role = new p_grab_role();
			this.role.fill2c(ba);
		}
	}
}