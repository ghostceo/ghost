using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_mountdown_tos:OutgoingBase{
	//ID
	public int protocolID = 808;

	//fields
	public int mountid = 0;
	public int bagid = 0;
	public int position = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(808);
		ba.WriteInt(this.mountid);
		ba.WriteInt(this.bagid);
		ba.WriteInt(this.position);
	}
}