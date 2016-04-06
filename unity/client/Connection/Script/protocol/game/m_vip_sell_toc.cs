using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_sell_toc:IncommingBase{
	//ID
	public int protocolID = 7417;

	//fields
	public int buy_id = 0;
	public int err_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.buy_id = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}