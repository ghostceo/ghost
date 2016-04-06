using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_inherit_tos:OutgoingBase{
	//ID
	public int protocolID = 829;

	//fields
	public int from_equip = 0;
	public int to_equip = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(829);
		ba.WriteInt(this.from_equip);
		ba.WriteInt(this.to_equip);
	}
}