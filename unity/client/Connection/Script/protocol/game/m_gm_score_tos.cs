using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_gm_score_tos:OutgoingBase{
	//ID
	public int protocolID = 4002;

	//fields
	public int id = 0;
	public int fraction = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(4002);
		ba.WriteInt(this.id);
		ba.WriteInt(this.fraction);
	}
}