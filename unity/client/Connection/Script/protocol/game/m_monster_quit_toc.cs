using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_monster_quit_toc:IncommingBase{
	//ID
	public int protocolID = 1802;

	//fields
	public int monsterid = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.monsterid = ba.ReadInt();
	}
}