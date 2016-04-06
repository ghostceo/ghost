using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_grab_add_protect_toc:IncommingBase{
	//ID
	public int protocolID = 11004;

	//fields
	public int type = 0;
	public int gold = 0;
	public int hour = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.gold = ba.ReadInt();
		this.hour = ba.ReadInt();
	}
}