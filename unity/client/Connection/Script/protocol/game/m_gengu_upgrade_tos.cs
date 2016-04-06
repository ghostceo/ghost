using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_gengu_upgrade_tos:OutgoingBase{
	//ID
	public int protocolID = 17502;

	//fields
	public bool is_auto_buy = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(17502);
		ba.WriteBool(this.is_auto_buy);
	}
}