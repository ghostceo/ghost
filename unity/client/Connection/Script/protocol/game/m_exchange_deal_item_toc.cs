using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_exchange_deal_item_toc:IncommingBase{
	//ID
	public int protocolID = 2207;

	//fields
	public int deal_id = 0;
	public int num = 0;
	public int type = 0;
	public int err_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.deal_id = ba.ReadInt();
		this.num = ba.ReadInt();
		this.type = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}