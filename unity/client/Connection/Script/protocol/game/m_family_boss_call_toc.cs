using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_boss_call_toc:IncommingBase{
	//ID
	public int protocolID = 3180;

	//fields
	public int err_code = 0;
	public string reason;
	public int boss_type = 0;
	public p_family_boss_call boss_call;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.boss_type = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.boss_call = new p_family_boss_call();
			this.boss_call.fill2c(ba);
		}
	}
}