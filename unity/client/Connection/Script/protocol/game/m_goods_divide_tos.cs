using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_goods_divide_tos:OutgoingBase{
	//ID
	public int protocolID = 2005;

	//fields
	public int id = 0;
	public int num = 0;
	public int bagposition = 0;
	public int bagid = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2005);
		ba.WriteInt(this.id);
		ba.WriteInt(this.num);
		ba.WriteInt(this.bagposition);
		ba.WriteInt(this.bagid);
	}
}