using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_get_goods_tos:OutgoingBase{
	//ID
	public int protocolID = 918;

	//fields
	public int goods_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(918);
		ba.WriteInt(this.goods_id);
	}
}