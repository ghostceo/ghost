using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_main_fb_buy_toc:IncommingBase{
	//ID
	public int protocolID = 8104;

	//fields
	public int err_code = 0;
	public string reason;
	public int remain_count = 0;
	public int buy_count = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.remain_count = ba.ReadInt();
		this.buy_count = ba.ReadInt();
	}
}