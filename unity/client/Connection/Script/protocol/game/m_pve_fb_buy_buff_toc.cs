using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pve_fb_buy_buff_toc:IncommingBase{
	//ID
	public int protocolID = 9402;

	//fields
	public int type = 0;
	public int err_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}