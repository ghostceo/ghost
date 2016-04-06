using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_guide_finish_tos:OutgoingBase{
	//ID
	public int protocolID = 19002;

	//fields
	public int mission_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(19002);
		ba.WriteInt(this.mission_id);
	}
}