using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_gengu_info_toc:IncommingBase{
	//ID
	public int protocolID = 17501;

	//fields
	public p_gengu_info gengu;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.gengu = new p_gengu_info();
			this.gengu.fill2c(ba);
		}
	}
}