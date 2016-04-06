using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_request_toc:IncommingBase{
	//ID
	public int protocolID = 3102;

	//fields
	public bool succ = true;
	public string reason;
	public bool return_self = true;
	public p_family_request request;
	public int family_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.request = new p_family_request();
			this.request.fill2c(ba);
		}
		this.family_id = ba.ReadInt();
	}
}