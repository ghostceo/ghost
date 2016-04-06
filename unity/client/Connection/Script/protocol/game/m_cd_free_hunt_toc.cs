using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_cd_free_hunt_toc:IncommingBase{
	//ID
	public int protocolID = 18703;

	//fields
	public int type = 0;
	public int free_count = 0;
	public int free_cd_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.free_count = ba.ReadInt();
		this.free_cd_time = ba.ReadInt();
	}
}