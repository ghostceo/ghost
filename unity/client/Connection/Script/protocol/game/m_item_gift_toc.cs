using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_item_gift_toc:IncommingBase{
	//ID
	public int protocolID = 1103;

	//fields
	public ArrayList goods_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.goods_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.goods_list.Add(p);
		}
	}
}