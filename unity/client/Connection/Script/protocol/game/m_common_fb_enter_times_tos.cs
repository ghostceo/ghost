using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_common_fb_enter_times_tos:OutgoingBase{
	//ID
	public int protocolID = 17306;

	//fields
	public int fb_map_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(17306);
		ba.WriteInt(this.fb_map_id);
	}
}