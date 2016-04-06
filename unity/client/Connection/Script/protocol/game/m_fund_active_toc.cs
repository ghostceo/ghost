using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fund_active_toc:IncommingBase{
	//ID
	public int protocolID = 18901;

	//fields
	public p_role_fund info;
	public int first_return_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.info = new p_role_fund();
			this.info.fill2c(ba);
		}
		this.first_return_gold = ba.ReadInt();
	}
}