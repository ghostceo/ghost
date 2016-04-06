using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_caishen_confirm_toc:IncommingBase{
	//ID
	public int protocolID = 10005;

	//fields
	public int get_coin = 0;
	public int cost_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.get_coin = ba.ReadInt();
		this.cost_gold = ba.ReadInt();
	}
}