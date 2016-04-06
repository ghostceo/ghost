using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_sms_send_toc:IncommingBase{
	//ID
	public int protocolID = 11901;

	//fields
	public ArrayList sms_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.sms_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_sms p = new p_sms();
			p.fill2c(ba);
			this.sms_list.Add(p);
		}
	}
}