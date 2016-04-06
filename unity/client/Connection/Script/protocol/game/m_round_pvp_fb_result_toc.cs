using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_round_pvp_fb_result_toc:IncommingBase{
	//ID
	public int protocolID = 10805;

	//fields
	public int win_role = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.win_role = ba.ReadInt();
	}
}