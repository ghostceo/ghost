using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_daily_activity_info_toc:IncommingBase{
	//ID
	public int protocolID = 18601;

	//fields
	public int err_code = 0;
	public string reason;
	public ArrayList info_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.info_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_daily_activity p = new p_daily_activity();
			p.fill2c(ba);
			this.info_list.Add(p);
		}
	}
}