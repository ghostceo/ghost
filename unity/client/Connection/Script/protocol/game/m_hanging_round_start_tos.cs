using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_round_start_tos:OutgoingBase{
	//ID
	public int protocolID = 2312;

	//fields
	public int select_sanyuan = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2312);
		ba.WriteInt(this.select_sanyuan);
	}
}