using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_buff_toc:IncommingBase{
	//ID
	public int protocolID = 2316;

	//fields
	public p_hanging_buff hanging_buff;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.hanging_buff = new p_hanging_buff();
			this.hanging_buff.fill2c(ba);
		}
	}
}