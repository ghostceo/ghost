using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_join_limit_tos:OutgoingBase{
	//ID
	public int protocolID = 3183;

	//fields
	public int min_level = 0;
	public int min_fight_power = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3183);
		ba.WriteInt(this.min_level);
		ba.WriteInt(this.min_fight_power);
	}
}