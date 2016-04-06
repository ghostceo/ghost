using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_round_pvp_fb_state_toc:IncommingBase{
	//ID
	public int protocolID = 10804;

	//fields
	public int round = 0;
	public int begin_time = 0;
	public int end_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.round = ba.ReadInt();
		this.begin_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
	}
}