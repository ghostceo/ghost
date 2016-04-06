using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_exchange_deal_score_toc:IncommingBase{
	//ID
	public int protocolID = 2208;

	//fields
	public int honor_score = 0;
	public int stone_score = 0;
	public int prestige_score = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.honor_score = ba.ReadInt();
		this.stone_score = ba.ReadInt();
		this.prestige_score = ba.ReadInt();
	}
}