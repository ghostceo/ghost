using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rnkm_challenge_toc:IncommingBase{
	//ID
	public int protocolID = 11204;

	//fields
	public int rank = 0;
	public int role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.role_id = ba.ReadInt();
	}
}