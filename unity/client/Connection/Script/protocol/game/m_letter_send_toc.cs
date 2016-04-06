using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_send_toc:IncommingBase{
	//ID
	public int protocolID = 2111;

	//fields
	public bool succ = false;
	public p_letter_simple_info letter;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.letter = new p_letter_simple_info();
			this.letter.fill2c(ba);
		}
		this.reason = ba.ReadString();
	}
}