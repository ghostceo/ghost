using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_treasbox_get_toc:IncommingBase{
	//ID
	public int protocolID = 11803;

	//fields
	public int err_code = 0;
	public string reason;
	public ArrayList award_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.award_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.award_list.Add(p);
		}
	}
}