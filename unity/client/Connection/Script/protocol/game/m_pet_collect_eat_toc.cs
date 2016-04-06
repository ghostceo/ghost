using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_collect_eat_toc:IncommingBase{
	//ID
	public int protocolID = 1210;

	//fields
	public int type = 0;
	public p_pet_collect pet_collect;
	public int err_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pet_collect = new p_pet_collect();
			this.pet_collect.fill2c(ba);
		}
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}