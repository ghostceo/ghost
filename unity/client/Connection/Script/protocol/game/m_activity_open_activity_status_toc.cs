using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_open_activity_status_toc:IncommingBase{
	//ID
	public int protocolID = 5632;

	//fields
	public bool is_open = false;
	public ArrayList activity_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.is_open = ba.ReadBoolean();
		this.activity_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_open_activity p = new p_open_activity();
			p.fill2c(ba);
			this.activity_list.Add(p);
		}
	}
}