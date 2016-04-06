using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_change_relative_toc:IncommingBase{
	//ID
	public int protocolID = 1013;

	//fields
	public int role_id = 0;
	public ArrayList relative;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.relative = new ArrayList();
		ba.ReadIntArray(this.relative);
	}
}