using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fund_level_info_toc:IncommingBase{
	//ID
	public int protocolID = 18903;

	//fields
	public bool is_buyed = false;
	public int fetched_level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.is_buyed = ba.ReadBoolean();
		this.fetched_level = ba.ReadInt();
	}
}