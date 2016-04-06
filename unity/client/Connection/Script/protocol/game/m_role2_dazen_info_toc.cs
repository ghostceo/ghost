using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_dazen_info_toc:IncommingBase{
	//ID
	public int protocolID = 563;

	//fields
	public int unit_secs = 0;
	public int unit_exp = 0;
	public int cur_exp = 0;
	public int max_exp = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.unit_secs = ba.ReadInt();
		this.unit_exp = ba.ReadInt();
		this.cur_exp = ba.ReadInt();
		this.max_exp = ba.ReadInt();
	}
}