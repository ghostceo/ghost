using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fund_active_tos:OutgoingBase{
	//ID
	public int protocolID = 18901;

	//fields
	public int fund_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(18901);
		ba.WriteInt(this.fund_type);
	}
}