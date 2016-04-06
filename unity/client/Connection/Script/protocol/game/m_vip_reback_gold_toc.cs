using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_reback_gold_toc:IncommingBase{
	//ID
	public int protocolID = 7407;

	//fields
	public bool succ = true;
	public string reason;
	public int return_gold_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_gold_num = ba.ReadInt();
	}
}