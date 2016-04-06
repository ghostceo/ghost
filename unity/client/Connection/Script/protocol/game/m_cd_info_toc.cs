using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_cd_info_toc:IncommingBase{
	//ID
	public int protocolID = 18701;

	//fields
	public int cd_type = 0;
	public int end_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.cd_type = ba.ReadInt();
		this.end_time = ba.ReadInt();
	}
}