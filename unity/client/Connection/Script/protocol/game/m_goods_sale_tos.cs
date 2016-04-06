using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_goods_sale_tos:OutgoingBase{
	//ID
	public int protocolID = 2011;

	//fields
	public int id = 0;
	public int num = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2011);
		ba.WriteInt(this.id);
		ba.WriteInt(this.num);
	}
}