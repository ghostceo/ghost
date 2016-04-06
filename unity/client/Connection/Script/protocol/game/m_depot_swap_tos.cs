using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_swap_tos:OutgoingBase{
	//ID
	public int protocolID = 2704;

	//fields
	public int goodsid = 0;
	public int position = 0;
	public int bagid = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2704);
		ba.WriteInt(this.goodsid);
		ba.WriteInt(this.position);
		ba.WriteInt(this.bagid);
	}
}