using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_gift_limited_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 15401;

	//fields
	public int type_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(15401);
		ba.WriteInt(this.type_id);
	}
}