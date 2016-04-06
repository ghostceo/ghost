using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pve_fb_buff_list_toc:IncommingBase{
	//ID
	public int protocolID = 9401;

	//fields
	public ArrayList buff_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.buff_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_pve_fb_buff_info p = new p_pve_fb_buff_info();
			p.fill2c(ba);
			this.buff_list.Add(p);
		}
	}
}