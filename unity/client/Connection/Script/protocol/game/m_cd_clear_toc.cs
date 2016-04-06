using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_cd_clear_toc:IncommingBase{
	//ID
	public int protocolID = 18702;

	//fields
	public int cd_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.cd_type = ba.ReadInt();
	}
}