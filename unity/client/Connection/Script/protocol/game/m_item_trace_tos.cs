using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_item_trace_tos:OutgoingBase{
	//ID
	public int protocolID = 1105;

	//fields
	public string target_name;
	public int goods_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1105);
		ba.WriteString(this.target_name);
		ba.WriteInt(this.goods_id);
	}
}