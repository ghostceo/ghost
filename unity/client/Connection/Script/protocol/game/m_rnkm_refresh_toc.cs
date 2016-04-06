using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rnkm_refresh_toc:IncommingBase{
	//ID
	public int protocolID = 11218;

	//fields
	public ArrayList mirrors;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.mirrors = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_rnkm_mirror p = new p_rnkm_mirror();
			p.fill2c(ba);
			this.mirrors.Add(p);
		}
	}
}