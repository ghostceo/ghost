using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_call_back_toc:IncommingBase{
	//ID
	public int protocolID = 1206;

	//fields
	public bool succ = true;
	public string reason;
	public int pet_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.pet_id = ba.ReadInt();
	}
}