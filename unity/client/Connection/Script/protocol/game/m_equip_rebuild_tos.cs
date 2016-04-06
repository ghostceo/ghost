using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_rebuild_tos:OutgoingBase{
	//ID
	public int protocolID = 831;

	//fields
	public int type = 0;
	public ArrayList rebuild_list;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(831);
		ba.WriteInt(this.type);
		ba.WriteIntArray(this.rebuild_list);
	}
}