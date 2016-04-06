using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_donate_toc:IncommingBase{
	//ID
	public int protocolID = 3175;

	//fields
	public bool succ = true;
	public string reason;
	public int reason_code = 0;
	public int donate_type = 0;
	public p_role_family_donate_info donate_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.reason_code = ba.ReadInt();
		this.donate_type = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.donate_info = new p_role_family_donate_info();
			this.donate_info.fill2c(ba);
		}
	}
}