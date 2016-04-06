using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_danyao_eat_tos:OutgoingBase{
	//ID
	public int protocolID = 3702;

	//fields
	public int type = 0;
	public bool auto_buy = false;
	public bool auto_compose = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3702);
		ba.WriteInt(this.type);
		ba.WriteBool(this.auto_buy);
		ba.WriteBool(this.auto_compose);
	}
}