using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_time_activity_info_toc:IncommingBase{
	//ID
	public int protocolID = 19501;

	//fields
	public ArrayList info;
	public ArrayList org_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.info = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_time_activity p = new p_time_activity();
			p.fill2c(ba);
			this.info.Add(p);
		}
		this.org_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_org_activity p = new p_org_activity();
			p.fill2c(ba);
			this.org_list.Add(p);
		}
	}
}