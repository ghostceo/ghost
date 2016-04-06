using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_treasbox_open_tos:OutgoingBase{
	//ID
	public int protocolID = 11802;

	//fields
	public int op_fee_type = 0;
	public int num_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(11802);
		ba.WriteInt(this.op_fee_type);
		ba.WriteInt(this.num_type);
	}
}