using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_dazen_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 564;

	//fields
	public int fetch_type = 0;
	public int cur_exp = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.fetch_type = ba.ReadInt();
		this.cur_exp = ba.ReadInt();
	}
}