using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_treasbox_refresh_toc:IncommingBase{
	//ID
	public int protocolID = 11804;

	//fields
	public ArrayList luck_value;
	public ArrayList item_num;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.luck_value = new ArrayList();
		ba.ReadIntArray(this.luck_value);
		this.item_num = new ArrayList();
		ba.ReadIntArray(this.item_num);
	}
}