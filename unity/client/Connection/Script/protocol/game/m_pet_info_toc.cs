using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_info_toc:IncommingBase{
	//ID
	public int protocolID = 1207;

	//fields
	public bool succ = true;
	public string reason;
	public p_pet pet_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.pet_info = new p_pet();
			this.pet_info.fill2c(ba);
		}
	}
}