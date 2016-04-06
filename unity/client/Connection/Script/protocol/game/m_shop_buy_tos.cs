using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_buy_tos:OutgoingBase{
	//ID
	public int protocolID = 1301;

	//fields
	public int goods_id = 0;
	public int price_id = 0;
	public int goods_num = 0;
	public int shop_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1301);
		ba.WriteInt(this.goods_id);
		ba.WriteInt(this.price_id);
		ba.WriteInt(this.goods_num);
		ba.WriteInt(this.shop_id);
	}
}