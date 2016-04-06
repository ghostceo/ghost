using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_shops_toc:IncommingBase{
	//ID
	public int protocolID = 1302;

	//fields
	public ArrayList shops;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.shops = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_shop_info p = new p_shop_info();
			p.fill2c(ba);
			this.shops.Add(p);
		}
	}
}