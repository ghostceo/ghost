using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_monster_war_wave_toc:IncommingBase{
	//ID
	public int protocolID = 10902;

	//fields
	public int wave = 0;
	public int next_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.wave = ba.ReadInt();
		this.next_time = ba.ReadInt();
	}
}