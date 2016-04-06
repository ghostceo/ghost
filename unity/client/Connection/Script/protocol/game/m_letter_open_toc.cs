using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_open_toc:IncommingBase{
	//ID
	public int protocolID = 2107;

	//fields
	public bool succ = false;
	public p_letter_info result;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.result = new p_letter_info();
			this.result.fill2c(ba);
		}
		this.reason = ba.ReadString();
	}
}