using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_watch_tos:OutgoingBase{
	//ID
	public int protocolID = 2310;

	//fields
	public bool is_watching = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2310);
		ba.WriteBool(this.is_watching);
	}
}