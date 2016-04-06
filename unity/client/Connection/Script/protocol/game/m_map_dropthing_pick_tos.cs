using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_dropthing_pick_tos:OutgoingBase{
	//ID
	public int protocolID = 305;

	//fields
	public int dropthingid = 0;
	public bool isguaji = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(305);
		ba.WriteInt(this.dropthingid);
		ba.WriteBool(this.isguaji);
	}
}