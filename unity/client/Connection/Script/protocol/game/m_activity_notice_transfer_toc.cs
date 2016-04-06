using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_notice_transfer_toc:IncommingBase{
	//ID
	public int protocolID = 5613;

	//fields
	public int activity_id = 0;
	public int npc_id = 0;
	public int error_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.activity_id = ba.ReadInt();
		this.npc_id = ba.ReadInt();
		this.error_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}