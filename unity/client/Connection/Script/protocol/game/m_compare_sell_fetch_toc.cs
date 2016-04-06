using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_compare_sell_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 17601;

	//fields
	public bool succ = false;
	public int id = 0;
	public int tag = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.id = ba.ReadInt();
		this.tag = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}