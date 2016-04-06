using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rnkm_notify_toc:IncommingBase{
	//ID
	public int protocolID = 11216;

	//fields
	public int notify_type = 0;
	public int challengerid = 0;
	public string challengername;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.notify_type = ba.ReadInt();
		this.challengerid = ba.ReadInt();
		this.challengername = ba.ReadString();
	}
}