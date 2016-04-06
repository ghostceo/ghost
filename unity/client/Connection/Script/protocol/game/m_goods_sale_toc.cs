using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_goods_sale_toc:IncommingBase{
	//ID
	public int protocolID = 2011;

	//fields
	public int err_code = 0;
	public string reason;
	public int sell_type = 0;
	public int sell_price = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.sell_type = ba.ReadInt();
		this.sell_price = ba.ReadInt();
	}
}