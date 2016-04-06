using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_common_fb_kill_report_toc:IncommingBase{
	//ID
	public int protocolID = 17307;

	//fields
	public int kill_num = 0;
	public int max_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.kill_num = ba.ReadInt();
		this.max_num = ba.ReadInt();
	}
}