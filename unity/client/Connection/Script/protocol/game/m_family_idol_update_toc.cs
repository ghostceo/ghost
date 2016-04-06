using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_idol_update_toc:IncommingBase{
	//ID
	public int protocolID = 11704;

	//fields
	public p_family_pray_rec pray_record;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.pray_record = new p_family_pray_rec();
			this.pray_record.fill2c(ba);
		}
	}
}