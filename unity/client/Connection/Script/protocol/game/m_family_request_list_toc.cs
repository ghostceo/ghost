using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_request_list_toc:IncommingBase{
	//ID
	public int protocolID = 3184;

	//fields
	public bool succ = true;
	public string reason;
	public ArrayList request_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.request_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_request p = new p_family_request();
			p.fill2c(ba);
			this.request_list.Add(p);
		}
	}
}