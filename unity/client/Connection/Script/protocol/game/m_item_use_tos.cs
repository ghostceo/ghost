using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_item_use_tos:OutgoingBase{
	//ID
	public int protocolID = 1102;

	//fields
	public int itemid = 0;
	public int usenum = 0;
	public int effect_id = 0;
	public int type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1102);
		ba.WriteInt(this.itemid);
		ba.WriteInt(this.usenum);
		ba.WriteInt(this.effect_id);
		ba.WriteInt(this.type);
	}
}