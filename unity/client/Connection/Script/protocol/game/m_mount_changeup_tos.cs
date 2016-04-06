using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_mount_changeup_tos:OutgoingBase{
	//ID
	public int protocolID = 16704;

	//fields
	public int dest_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(16704);
		ba.WriteInt(this.dest_id);
	}
}