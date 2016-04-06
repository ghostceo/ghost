using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_tili_info_toc:IncommingBase{
	//ID
	public int protocolID = 549;

	//fields
	public p_tili_info p_tili;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.p_tili = new p_tili_info();
			this.p_tili.fill2c(ba);
		}
	}
}