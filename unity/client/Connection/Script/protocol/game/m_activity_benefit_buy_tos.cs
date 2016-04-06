using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_benefit_buy_tos:OutgoingBase{
	//ID
	public int protocolID = 5607;

	//fields
	public int act_task_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(5607);
		ba.WriteInt(this.act_task_id);
	}
}