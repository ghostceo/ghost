using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_daily_activity_forecast_toc:IncommingBase{
	//ID
	public int protocolID = 18604;

	//fields
	public int id = 0;
	public int hour = 0;
	public int minute = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.hour = ba.ReadInt();
		this.minute = ba.ReadInt();
	}
}