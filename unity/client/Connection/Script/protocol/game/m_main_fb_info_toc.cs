using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_main_fb_info_toc:IncommingBase{
	//ID
	public int protocolID = 8101;

	//fields
	public p_main_fb_info info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.info = new p_main_fb_info();
			this.info.fill2c(ba);
		}
	}
}