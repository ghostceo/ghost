using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_list_toc:IncommingBase{
	//ID
	public int protocolID = 3115;

	//fields
	public ArrayList family_list;
	public int total_page = 0;
	public int page_id = 0;
	public int request_from = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.family_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_summary p = new p_family_summary();
			p.fill2c(ba);
			this.family_list.Add(p);
		}
		this.total_page = ba.ReadInt();
		this.page_id = ba.ReadInt();
		this.request_from = ba.ReadInt();
	}
}