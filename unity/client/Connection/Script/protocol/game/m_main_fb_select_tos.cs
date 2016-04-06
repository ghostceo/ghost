using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_main_fb_select_tos:OutgoingBase{
	//ID
	public int protocolID = 8102;

	//fields
	public int barrier_type = 0;
	public int barrier_id = 0;
	public ArrayList order_list;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(8102);
		ba.WriteInt(this.barrier_type);
		ba.WriteInt(this.barrier_id);
		ba.WriteIntArray(this.order_list);
	}
}