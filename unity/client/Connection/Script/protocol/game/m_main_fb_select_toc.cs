using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_main_fb_select_toc:IncommingBase{
	//ID
	public int protocolID = 8102;

	//fields
	public int err_code = 0;
	public string reason;
	public int barrier_type = 0;
	public int barrier_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.barrier_type = ba.ReadInt();
		this.barrier_id = ba.ReadInt();
	}
}