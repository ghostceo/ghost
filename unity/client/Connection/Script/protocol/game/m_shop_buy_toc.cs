using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_buy_toc:IncommingBase{
	//ID
	public int protocolID = 1301;

	//fields
	public bool succ = false;
	public string reason;
	public int shop_id = 0;
	public int error_code = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.shop_id = ba.ReadInt();
		this.error_code = ba.ReadInt();
	}
}