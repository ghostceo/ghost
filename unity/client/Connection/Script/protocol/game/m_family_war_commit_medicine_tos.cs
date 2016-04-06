using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_war_commit_medicine_tos:OutgoingBase{
	//ID
	public int protocolID = 18004;

	//fields
	public int pos_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(18004);
		ba.WriteInt(this.pos_id);
	}
}