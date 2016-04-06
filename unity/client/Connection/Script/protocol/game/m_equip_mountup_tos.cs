using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_mountup_tos:OutgoingBase{
	//ID
	public int protocolID = 807;

	//fields
	public int mountid = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(807);
		ba.WriteInt(this.mountid);
	}
}