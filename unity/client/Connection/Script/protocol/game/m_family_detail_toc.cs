using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_detail_toc:IncommingBase{
	//ID
	public int protocolID = 3157;

	//fields
	public bool succ = true;
	public string reason;
	public p_family_info content;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.content = new p_family_info();
			this.content.fill2c(ba);
		}
	}
}