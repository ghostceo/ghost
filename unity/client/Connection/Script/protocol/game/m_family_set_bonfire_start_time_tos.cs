using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_set_bonfire_start_time_tos:OutgoingBase{
	//ID
	public int protocolID = 3168;

	//fields
	public int hour = 0;
	public int minute = 0;
	public int seconds = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3168);
		ba.WriteInt(this.hour);
		ba.WriteInt(this.minute);
		ba.WriteInt(this.seconds);
	}
}