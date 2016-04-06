using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rnkm_update_mirror_toc:IncommingBase{
	//ID
	public int protocolID = 11206;

	//fields
	public p_rnkm_mirror mirror;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.mirror = new p_rnkm_mirror();
			this.mirror.fill2c(ba);
		}
	}
}