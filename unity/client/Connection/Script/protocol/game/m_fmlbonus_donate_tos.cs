using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlbonus_donate_tos:OutgoingBase{
	//ID
	public int protocolID = 20302;

	//fields
	public int goods_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(20302);
		ba.WriteInt(this.goods_id);
	}
}