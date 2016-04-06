using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_all_goods_tos:OutgoingBase{
	//ID
	public int protocolID = 1303;

	//fields
	public int shop_id = 0;
	public int npc_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1303);
		ba.WriteInt(this.shop_id);
		ba.WriteInt(this.npc_id);
	}
}