using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_common_fb_lianzhan_toc:IncommingBase{
	//ID
	public int protocolID = 17304;

	//fields
	public int role_id = 0;
	public int lianzhan = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.lianzhan = ba.ReadInt();
	}
}