using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_payment_request_toc:IncommingBase{
	//ID
	public int protocolID = 19903;

	//fields
	public int type = 0;
	public string notify_url;
	public string out_trade_no;
	public ArrayList args;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.notify_url = ba.ReadString();
		this.out_trade_no = ba.ReadString();
		this.args = new ArrayList();
		ba.ReadStringArray(this.args);
	}
}