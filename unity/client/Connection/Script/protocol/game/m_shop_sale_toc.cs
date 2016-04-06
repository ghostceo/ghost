using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_sale_toc:IncommingBase{
	//ID
	public int protocolID = 1306;

	//fields
	public bool succ = false;
	public ArrayList property;
	public ArrayList ids;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.property = new ArrayList();
		ba.ReadIntArray(this.property);
		this.ids = new ArrayList();
		ba.ReadIntArray(this.ids);
		this.reason = ba.ReadString();
	}
}