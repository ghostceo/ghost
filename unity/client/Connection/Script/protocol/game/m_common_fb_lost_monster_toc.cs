using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_common_fb_lost_monster_toc:IncommingBase{
	//ID
	public int protocolID = 17303;

	//fields
	public int lost_num = 0;
	public int max_can_lost = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.lost_num = ba.ReadInt();
		this.max_can_lost = ba.ReadInt();
	}
}