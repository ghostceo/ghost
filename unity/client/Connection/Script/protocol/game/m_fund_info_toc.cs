using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fund_info_toc:IncommingBase{
	//ID
	public int protocolID = 18900;

	//fields
	public ArrayList fund_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.fund_info = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_fund p = new p_role_fund();
			p.fill2c(ba);
			this.fund_info.Add(p);
		}
	}
}