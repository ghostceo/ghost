using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_daily_benefit_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 18802;

	//fields
	public int id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(18802);
		ba.WriteInt(this.id);
	}
}