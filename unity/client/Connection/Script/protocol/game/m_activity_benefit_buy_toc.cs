using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_benefit_buy_toc:IncommingBase{
	//ID
	public int protocolID = 5607;

	//fields
	public bool succ = true;
	public string reason;
	public int act_task_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.act_task_id = ba.ReadInt();
	}
}