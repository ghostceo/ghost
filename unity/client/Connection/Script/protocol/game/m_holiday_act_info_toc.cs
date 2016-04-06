using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_holiday_act_info_toc:IncommingBase{
	//ID
	public int protocolID = 20101;

	//fields
	public bool has_login_gift = false;
	public int gold_act = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.has_login_gift = ba.ReadBoolean();
		this.gold_act = ba.ReadInt();
	}
}