using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_boss_group_tos:OutgoingBase{
	//ID
	public int protocolID = 5610;

	//fields
	public int op_type = 0;
	public int boss_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(5610);
		ba.WriteInt(this.op_type);
		ba.WriteInt(this.boss_id);
	}
}