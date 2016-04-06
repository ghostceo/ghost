using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_tower_fb_result_toc:IncommingBase{
	//ID
	public int protocolID = 19305;

	//fields
	public int state = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.state = ba.ReadInt();
	}
}