using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_money_toc:IncommingBase{
	//ID
	public int protocolID = 3137;

	//fields
	public int new_money = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.new_money = ba.ReadInt();
	}
}