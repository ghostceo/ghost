using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_version_notice_toc:IncommingBase{
	//ID
	public int protocolID = 2601;

	//fields
	public string notice;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.notice = ba.ReadString();
	}
}