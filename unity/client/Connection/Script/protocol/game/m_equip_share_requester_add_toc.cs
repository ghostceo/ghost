using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_share_requester_add_toc:IncommingBase{
	//ID
	public int protocolID = 845;

	//fields
	public p_role_snapshot role;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.role = new p_role_snapshot();
			this.role.fill2c(ba);
		}
	}
}