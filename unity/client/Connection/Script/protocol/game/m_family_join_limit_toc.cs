using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_join_limit_toc:IncommingBase{
	//ID
	public int protocolID = 3183;

	//fields
	public int err_code = 0;
	public int min_level = 0;
	public int min_fight_power = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.min_level = ba.ReadInt();
		this.min_fight_power = ba.ReadInt();
	}
}