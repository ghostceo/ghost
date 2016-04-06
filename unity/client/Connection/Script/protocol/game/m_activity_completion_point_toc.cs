using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_completion_point_toc:IncommingBase{
	//ID
	public int protocolID = 5630;

	//fields
	public int pay_gold = 0;
	public int err_code = 0;
	public string reason;
	public int point = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pay_gold = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.point = ba.ReadInt();
	}
}