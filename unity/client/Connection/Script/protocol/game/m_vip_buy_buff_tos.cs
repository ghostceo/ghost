using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_buy_buff_tos:OutgoingBase{
	//ID
	public int protocolID = 7412;

	//fields
	public int op_type = 0;
	public int buy_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(7412);
		ba.WriteInt(this.op_type);
		ba.WriteInt(this.buy_type);
	}
}