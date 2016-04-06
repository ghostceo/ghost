using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_hpmp_change_toc:IncommingBase{
	//ID
	public int protocolID = 516;

	//fields
	public int hp = 0;
	public int mp = 0;
	public int is_show_hp_effect = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.hp = ba.ReadInt();
		this.mp = ba.ReadInt();
		this.is_show_hp_effect = ba.ReadInt();
	}
}