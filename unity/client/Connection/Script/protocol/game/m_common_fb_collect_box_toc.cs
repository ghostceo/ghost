using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_common_fb_collect_box_toc:IncommingBase{
	//ID
	public int protocolID = 17305;

	//fields
	public int num = 0;
	public int max_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.num = ba.ReadInt();
		this.max_num = ba.ReadInt();
	}
}