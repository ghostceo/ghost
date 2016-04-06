using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_item_tos:OutgoingBase{
	//ID
	public int protocolID = 1307;

	//fields
	public int shop_id = 0;
	public int item_type_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1307);
		ba.WriteInt(this.shop_id);
		ba.WriteInt(this.item_type_id);
	}
}