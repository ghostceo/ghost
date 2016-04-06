using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_monster_attr_change_toc:IncommingBase{
	//ID
	public int protocolID = 1804;

	//fields
	public int monsterid = 0;
	public int change_type = 0;
	public int value = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.monsterid = ba.ReadInt();
		this.change_type = ba.ReadInt();
		this.value = ba.ReadInt();
	}
}