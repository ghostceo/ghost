using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_caishen_firecoin_info_toc:IncommingBase{
	//ID
	public int protocolID = 10003;

	//fields
	public p_caishen_coin caishen_info;
	public int left_item_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.caishen_info = new p_caishen_coin();
			this.caishen_info.fill2c(ba);
		}
		this.left_item_num = ba.ReadInt();
	}
}