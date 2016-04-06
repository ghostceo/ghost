using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_exchange_deal_item_tos:OutgoingBase{
	//ID
	public int protocolID = 2207;

	//fields
	public int deal_id = 0;
	public int num = 0;
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2207);
		ba.WriteInt(this.deal_id);
		ba.WriteInt(this.num);
		ba.WriteInt(this.type);
	}
}