using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_grab_challenge_toc:IncommingBase{
	//ID
	public int protocolID = 11002;

	//fields
	public int mirror_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.mirror_id = ba.ReadInt();
	}
}