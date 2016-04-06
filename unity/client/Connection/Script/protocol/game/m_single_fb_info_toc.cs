using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_single_fb_info_toc:IncommingBase{
	//ID
	public int protocolID = 11301;

	//fields
	public ArrayList fb_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.fb_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_single_fb p = new p_single_fb();
			p.fill2c(ba);
			this.fb_list.Add(p);
		}
	}
}