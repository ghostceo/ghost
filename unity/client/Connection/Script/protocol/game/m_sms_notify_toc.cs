using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_sms_notify_toc:IncommingBase{
	//ID
	public int protocolID = 11902;

	//fields
	public int sms_type = 0;
	public string content;
	public ArrayList args;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.sms_type = ba.ReadInt();
		this.content = ba.ReadString();
		this.args = new ArrayList();
		ba.ReadIntArray(this.args);
	}
}