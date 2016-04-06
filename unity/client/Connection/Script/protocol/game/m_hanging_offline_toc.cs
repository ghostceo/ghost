using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_offline_toc:IncommingBase{
	//ID
	public int protocolID = 2303;

	//fields
	public p_hanging_offline_report report;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.report = new p_hanging_offline_report();
			this.report.fill2c(ba);
		}
	}
}