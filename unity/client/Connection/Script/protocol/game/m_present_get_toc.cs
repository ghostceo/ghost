using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_present_get_toc:IncommingBase{
	//ID
	public int protocolID = 6802;

	//fields
	public int err_code = 0;
	public string reason;
	public int present_id = 0;
	public p_present_info present_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.present_id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.present_info = new p_present_info();
			this.present_info.fill2c(ba);
		}
	}
}