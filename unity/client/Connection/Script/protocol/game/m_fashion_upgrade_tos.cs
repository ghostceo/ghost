using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fashion_upgrade_tos:OutgoingBase{
	//ID
	public int protocolID = 2503;

	//fields
	public int mountid = 0;
	public bool is_auto_buy = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2503);
		ba.WriteInt(this.mountid);
		ba.WriteBool(this.is_auto_buy);
	}
}