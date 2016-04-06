using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_level_gift_list_toc:IncommingBase{
	//ID
	public int protocolID = 6201;

	//fields
	public int cur_max_lv = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.cur_max_lv = ba.ReadInt();
	}
}