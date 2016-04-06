using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_exp_back_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 5615;

	//fields
	public int id = 0;
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(5615);
		ba.WriteInt(this.id);
		ba.WriteInt(this.type);
	}
}