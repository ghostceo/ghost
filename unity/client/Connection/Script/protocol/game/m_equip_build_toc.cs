using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_build_toc:IncommingBase{
	//ID
	public int protocolID = 832;

	//fields
	public int build_type = 0;
	public int gain_equip = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.build_type = ba.ReadInt();
		this.gain_equip = ba.ReadInt();
	}
}