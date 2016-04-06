using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_memberuplevel_toc:IncommingBase{
	//ID
	public int protocolID = 3142;

	//fields
	public int role_id = 0;
	public int new_level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.new_level = ba.ReadInt();
	}
}