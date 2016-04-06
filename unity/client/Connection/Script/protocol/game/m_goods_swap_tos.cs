using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_goods_swap_tos:OutgoingBase{
	//ID
	public int protocolID = 2002;

	//fields
	public int id1 = 0;
	public int position2 = 0;
	public int bagid2 = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2002);
		ba.WriteInt(this.id1);
		ba.WriteInt(this.position2);
		ba.WriteInt(this.bagid2);
	}
}