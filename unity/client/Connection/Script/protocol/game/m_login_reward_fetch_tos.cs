using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_login_reward_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 19101;

	//fields
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(19101);
	}
}