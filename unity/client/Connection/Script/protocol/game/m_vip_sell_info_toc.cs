using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_sell_info_toc:IncommingBase{
	//ID
	public int protocolID = 7416;

	//fields
	public int has_buy_list = 0;
	public int can_buy_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.has_buy_list = ba.ReadInt();
		this.can_buy_id = ba.ReadInt();
	}
}