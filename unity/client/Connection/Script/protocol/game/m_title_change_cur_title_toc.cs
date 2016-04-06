using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_title_change_cur_title_toc:IncommingBase{
	//ID
	public int protocolID = 4402;

	//fields
	public bool succ = true;
	public string reason;
	public string color;
	public int id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.color = ba.ReadString();
		this.id = ba.ReadInt();
	}
}