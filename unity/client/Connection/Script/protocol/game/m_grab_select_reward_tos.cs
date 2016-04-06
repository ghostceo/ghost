using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_grab_select_reward_tos:OutgoingBase{
	//ID
	public int protocolID = 11006;

	//fields
	public int select_num = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(11006);
		ba.WriteInt(this.select_num);
	}
}