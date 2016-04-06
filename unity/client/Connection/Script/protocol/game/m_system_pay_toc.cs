using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_pay_toc:IncommingBase{
	//ID
	public int protocolID = 3609;

	//fields
	public ArrayList pay_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pay_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_pay_item p = new p_pay_item();
			p.fill2c(ba);
			this.pay_list.Add(p);
		}
	}
}