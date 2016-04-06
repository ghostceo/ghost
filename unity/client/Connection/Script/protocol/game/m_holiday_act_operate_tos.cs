using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_holiday_act_operate_tos:OutgoingBase{
	//ID
	public int protocolID = 20102;

	//fields
	public int op_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(20102);
		ba.WriteInt(this.op_type);
	}
}