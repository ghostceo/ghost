using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rnkm_score_deal_tos:OutgoingBase{
	//ID
	public int protocolID = 11217;

	//fields
	public int op_type = 0;
	public int deal_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(11217);
		ba.WriteInt(this.op_type);
		ba.WriteInt(this.deal_id);
	}
}