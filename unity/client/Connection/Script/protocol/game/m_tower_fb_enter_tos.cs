using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_tower_fb_enter_tos:OutgoingBase{
	//ID
	public int protocolID = 19301;

	//fields
	public int enter_type = 0;
	public int barrier_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(19301);
		ba.WriteInt(this.enter_type);
		ba.WriteInt(this.barrier_id);
	}
}