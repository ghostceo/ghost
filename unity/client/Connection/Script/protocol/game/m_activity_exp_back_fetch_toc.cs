using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_exp_back_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 5615;

	//fields
	public int id = 0;
	public int type = 0;
	public int err_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.type = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}