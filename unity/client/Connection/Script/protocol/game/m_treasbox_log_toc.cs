using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_treasbox_log_toc:IncommingBase{
	//ID
	public int protocolID = 11805;

	//fields
	public bool is_open = true;
	public ArrayList log_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.is_open = ba.ReadBoolean();
		this.log_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_treasbox_log p = new p_treasbox_log();
			p.fill2c(ba);
			this.log_list.Add(p);
		}
	}
}