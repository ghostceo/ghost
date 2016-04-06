using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_consume_notice_toc:IncommingBase{
	//ID
	public int protocolID = 7411;

	//fields
	public int use_gold = 0;
	public int jifen = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.use_gold = ba.ReadInt();
		this.jifen = ba.ReadInt();
	}
}