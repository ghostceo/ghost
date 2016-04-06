using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_notice_start_toc:IncommingBase{
	//ID
	public int protocolID = 5611;

	//fields
	public int activity_id = 0;
	public int start_time = 0;
	public int end_time = 0;
	public int left_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.activity_id = ba.ReadInt();
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.left_time = ba.ReadInt();
	}
}