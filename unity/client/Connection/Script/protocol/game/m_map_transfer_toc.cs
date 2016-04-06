using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_transfer_toc:IncommingBase{
	//ID
	public int protocolID = 310;

	//fields
	public bool succ = true;
	public int scroll_id = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.scroll_id = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}