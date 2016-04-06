using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_fcm_toc:IncommingBase{
	//ID
	public int protocolID = 3601;

	//fields
	public string info;
	public int remain_time = 0;
	public int total_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.info = ba.ReadString();
		this.remain_time = ba.ReadInt();
		this.total_time = ba.ReadInt();
	}
}