using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_goods_show_goods_tos:OutgoingBase{
	//ID
	public int protocolID = 2008;

	//fields
	public string channel_sign;
	public string to_role_name;
	public int show_type = 0;
	public int goods_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2008);
		ba.WriteString(this.channel_sign);
		ba.WriteString(this.to_role_name);
		ba.WriteInt(this.show_type);
		ba.WriteInt(this.goods_id);
	}
}