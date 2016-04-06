using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_main_fb_quick_toc:IncommingBase{
	//ID
	public int protocolID = 8105;

	//fields
	public int err_code = 0;
	public string reason;
	public p_hanging_offline_report report;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.report = new p_hanging_offline_report();
			this.report.fill2c(ba);
		}
	}
}