using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_item_toc:IncommingBase{
	//ID
	public int protocolID = 1307;

	//fields
	public bool succ = true;
	public string reason;
	public int shop_id = 0;
	public p_shop_goods_info goods;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.shop_id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.goods = new p_shop_goods_info();
			this.goods.fill2c(ba);
		}
	}
}