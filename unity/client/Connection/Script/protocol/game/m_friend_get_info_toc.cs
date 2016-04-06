using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_get_info_toc:IncommingBase{
	//ID
	public int protocolID = 1017;

	//fields
	public p_friend_info roleinfo;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.roleinfo = new p_friend_info();
			this.roleinfo.fill2c(ba);
		}
	}
}