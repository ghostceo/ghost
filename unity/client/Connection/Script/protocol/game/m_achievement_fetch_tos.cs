using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_achievement_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 16801;

	//fields
	public int id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(16801);
		ba.WriteInt(this.id);
	}
}