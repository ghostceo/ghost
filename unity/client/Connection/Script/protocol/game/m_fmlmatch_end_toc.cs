using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlmatch_end_toc:IncommingBase{
	//ID
	public int protocolID = 20404;

	//fields
	public string win_family_name;
	public string win_owner_role_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.win_family_name = ba.ReadString();
		this.win_owner_role_name = ba.ReadString();
	}
}